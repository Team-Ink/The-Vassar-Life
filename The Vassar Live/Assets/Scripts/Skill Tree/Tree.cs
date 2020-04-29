using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tree : MonoBehaviour
//consider using subclasses for different trees
{
    #region Buttons and UI elements
    [SerializeField]
    public Button root;
    [SerializeField]
    public Button GSS;
    [SerializeField]
    public Button QP;
    [SerializeField]
    public Button MN;
    [SerializeField]
    public Button DC;
    [SerializeField]
    public Button TMS;
    [SerializeField]
    public Button TT;
    [SerializeField]
    public Button SHV;
    [SerializeField]
    public Button SSS;
    [SerializeField]
    public Button OAB;
    [SerializeField]
    public Button DWTT;
    [SerializeField]
    public Button LOT;
    [SerializeField]
    public Text SkillName;
    [SerializeField]
    public Text SkillEffect;
    [SerializeField]
    public Button backBtn;
    [SerializeField]
    public Button cancelBtn;
    [SerializeField]
    public Button activateBtn;
    #endregion

    #region social Skill
    Skill UnlockDeece = new Skill("Unlock Deece", "Unlocks the Gordon Commons.", new UnlockSkill("Deece", true));
    Skill GroupStudySkill = new Skill("Group Study Skill", "Gain 2 social per academic points at the library", new PointAs("Social", "Academic", 2, "Library"));
    Skill QuadPicnic = new Skill("Quad Picnic", "Gain 1.5x Happiness in Dorm.", new MultiplierSkill(new Attributes(1, 1, 1, 1, 1.5), "Dorm"));
    Skill MugNight = new Skill("Mug Night Over Moodle", "From this point onward, gain half academic points,  but gain 3x social points", new AllMultiplier(new Attributes(0.5, 1, 3, 1, 1)));
    Skill DeeceCaffine = new Skill("Fueled By Deece Caffine", "Gain 1 point in all categories every time you enter the Deece", new AddSkill(new Attributes(1, 1, 1, 1, 1), "Deece"));
    Skill TheMidnightScream = new Skill("The Midnight Scream and Joss Beach Pancakes", "Re-energize during finals weeks with screams and pancakes and friendship. " +
        "You have a newfound spirit of determination. Gain 2x social and 2x academics", new AllMultiplier(new Attributes(2, 1, 2, 1, 1)));
    //but we don't have burger fi??
    Skill TastyTuesday = new Skill("Tasty Tuesday Tradition", "Enjoy Tasty Tuesdays with friends and gain +3 social everytime you visit main.", new AddSkill(new Attributes(0, 0, 3, 0, 0), "Main"));
    Skill ScenicHudsonValley = new Skill("Scenic Hudson Valley", "Unlocks Sunset Lake", new UnlockSkill("Sunset Lake", true));
    Skill SusanSteinShiva = new Skill("Devoted to Susan Stein Shiva", "Vogelstein cards now give the  same amount of social points as art points", new PointAs("Social", "Art", 1, "Vogelstein"));
    Skill OfficiallyABrewer = new Skill("Officially a Brewer", "Athletic & Fitness Center cards now give the same amount of social as physique points", new PointAs("Social", "Physique", 1, "Gym"));
    Skill DeeceWithTheTeam = new Skill("Deece With the Team", "Draw 3 cards from Deece", new GiveCards("Deece", 3));
    Skill LeaderofTheater = new Skill("Leader of Theater", "Draw 3 cards from Vogelstein", new GiveCards("Vogelstein", 3));
    #endregion

    public Animator skillanim;
    public Button currentBtn;
    public Skill currentSkill;
    public UIHandler uh;
    public int i =0;

    int[] treeLevels = { 10, 20, 30, 45, 60, 80, 100, 125, 150, 175, 200, 230 };
    Dictionary<Button, Skill> SkillDict = new Dictionary<Button, Skill>();
    Dictionary<Button, bool> ButtonDict = new Dictionary<Button, bool>();

    Node SrootNode;

    void initSkillDict()
    {
        SkillDict.Add(root, UnlockDeece);
        SkillDict.Add(GSS, GroupStudySkill);
        SkillDict.Add(QP, QuadPicnic);
        SkillDict.Add(MN, MugNight);
        SkillDict.Add(DC, DeeceCaffine);
        SkillDict.Add(TMS, TheMidnightScream);
        SkillDict.Add(TT, TastyTuesday);
        SkillDict.Add(SHV, ScenicHudsonValley);
        SkillDict.Add(SSS, SusanSteinShiva);
        SkillDict.Add(OAB, OfficiallyABrewer);
        SkillDict.Add(DWTT, DeeceWithTheTeam);
        SkillDict.Add(LOT, LeaderofTheater);

        ButtonDict.Add(root, false);
        ButtonDict.Add(GSS, false);
        ButtonDict.Add(QP, false);
        ButtonDict.Add(MN, false);
        ButtonDict.Add(DC, false);
        ButtonDict.Add(TMS, false);
        ButtonDict.Add(TT, false);
        ButtonDict.Add(SHV, false);
        ButtonDict.Add(SSS, false);
        ButtonDict.Add(OAB, false);
        ButtonDict.Add(DWTT, false);
        ButtonDict.Add(LOT, false);
    }

    //use the default linked list

    #region Custom Linked list
    internal class Node
    {
        internal Skill skill;
        internal LinkedList<Node> children;
        public Node(Skill s)
        {
            skill = s;
            children = new LinkedList<Node>();
        }

        internal void addChild(Node child)
        {
            children.AddLast(child);
        }
    }
    #endregion

    private void Start()
    {
        buildSTree();
        SrootNode.skill.isUnlocked = true;
        initSkillDict();
        backBtn.onClick.AddListener(mainScene);
        cancelBtn.onClick.AddListener(cancel);
        skillanim = GameObject.Find("SkillPanel").GetComponent<Animator>();
        activateBtn.onClick.AddListener(delegate { activate(currentBtn); });
        foreach (KeyValuePair<Button, Skill> s in SkillDict)
        {
            s.Key.onClick.AddListener(delegate { inspect(s.Key); });
        }
    }

    //Used for testing. In the final version, only update every turn
    private void Update()
    {
        updateSTree();
        updateBtn();
    }


    public void buildSTree()
    {
        //uses linked lists to init tree of skill nodes (enum)
        SrootNode = new Node(UnlockDeece);
        Node GSSNode = new Node(GroupStudySkill);
        Node QPNode = new Node(QuadPicnic);
        Node MNNode = new Node(MugNight);
        Node DCNode = new Node(DeeceCaffine);
        Node TMSNode = new Node(TheMidnightScream);
        Node TTNode = new Node(TastyTuesday);
        Node SHVNode = new Node(ScenicHudsonValley);
        Node SSSNode = new Node(SusanSteinShiva);
        Node OABNode = new Node(OfficiallyABrewer);
        Node DWTTNode = new Node(DeeceWithTheTeam);
        Node LOTNode = new Node(LeaderofTheater);
        SrootNode.addChild(GSSNode);
        SrootNode.addChild(QPNode);
        GSSNode.addChild(MNNode);
        GSSNode.addChild(DCNode);
        GSSNode.addChild(TTNode);
        DCNode.addChild(TMSNode);
        TTNode.addChild(SHVNode);
        QPNode.addChild(TTNode);
        QPNode.addChild(OABNode);
        QPNode.addChild(SSSNode);
        SSSNode.addChild(LOTNode);
        OABNode.addChild(DWTTNode);

    }

    public void updateSTree()
    {
        //at the beginning of every turn, check if the points satisfy the condi
        //update the state of different Skill

        //go through the tree, and if sees active Skill, make the next ones available
        Stack<Node> nodeStack = new Stack<Node>();
        nodeStack.Push(SrootNode);
        while (nodeStack.Count > 0)
        {
            //Take the node out of the stack
            Node curr = nodeStack.Pop();
            //stop if skill not available (we might have problems because the other "curr" might be unlocked

            //access its children and push them back in
            if (curr.skill.isActive && uh.points.S >= treeLevels[i])
            {
                foreach (Node child in curr.children)
                {
                    child.skill.isUnlocked = true;
                    nodeStack.Push(child);
                }
            }
        }
    }

    public void updateBtn()
    {
        if (!UnlockDeece.isActive)
            ButtonDict[root] = GroupStudySkill.isUnlocked;
        else
            ButtonDict[root] = false;
        if (!GroupStudySkill.isActive)
            ButtonDict[GSS] = GroupStudySkill.isUnlocked;
        else
        {
            ButtonDict[GSS] = false;
            //Text text = GSS.GetComponent<Text>();
            //text.text = "active";
        }
        if (!QuadPicnic.isActive)
            ButtonDict[QP] = QuadPicnic.isUnlocked;
        else
        {
            ButtonDict[QP] = false;
            //Text text = QP.GetComponent<Text>();
            //text.text = "active";
        }
        if (!MugNight.isActive)
            ButtonDict[MN] = MugNight.isUnlocked;
        else
        {
            ButtonDict[MN] = false;
            //Text text = MN.GetComponent<Text>();
            //text.text = "active";
        }
        if (!DeeceCaffine.isActive)
            ButtonDict[DC] = DeeceCaffine.isUnlocked;
        else
        {
            ButtonDict[DC] = false;
            //Text text = DC.GetComponent<Text>();
            //text.text = "active";
        }
        if (!TheMidnightScream.isActive)
            ButtonDict[TMS] = TheMidnightScream.isUnlocked;
        else
        {
            ButtonDict[TMS] = false;
            //Text text = TMS.GetComponent<Text>();
            //text.text = "active";
        }
        if (!TastyTuesday.isActive)
            ButtonDict[TT] = TastyTuesday.isUnlocked;
        else
        {
            ButtonDict[TT] = false;
            //Text text = TT.GetComponent<Text>();
            //text.text = "Active";
        }
        if (!ScenicHudsonValley.isActive)
            ButtonDict[SHV] = ScenicHudsonValley.isUnlocked;
        else
        {
            ButtonDict[SHV] = false;
            //Text text = SHV.GetComponent<Text>();
            //text.text = "active";
        }
        if (!SusanSteinShiva.isActive)
            ButtonDict[SSS] = SusanSteinShiva.isUnlocked;
        else
        {
            ButtonDict[SSS] = false;
            //Text text = SSS.GetComponent<Text>();
            //text.text = "active";
        }
        if (!OfficiallyABrewer.isActive)
            ButtonDict[OAB] = OfficiallyABrewer.isUnlocked;
        else
        {
            ButtonDict[OAB] = false;
            //Text text = OAB.GetComponent<Text>();
            //text.text = "active";
        }
        if (!DeeceWithTheTeam.isActive)
            ButtonDict[DWTT] = DeeceWithTheTeam.isUnlocked;
        else
        {
            ButtonDict[DWTT] = false;
            //Text text = DWTT.GetComponent<Text>();
            //text.text = "active";
        }
        if (!LeaderofTheater.isActive)
            ButtonDict[LOT] = LeaderofTheater.isUnlocked;
        else
        {
            ButtonDict[LOT] = false;
            //Text text = LOT.GetComponent<Text>();
            //text.text = "active";
        }
    }
    public void inspect(Button b)
    {
        SkillName.text = SkillDict[b].name;
        SkillEffect.text = SkillDict[b].description;
        skillanim.SetTrigger("SkillIn");
        backBtn.gameObject.SetActive(false);
        currentBtn = b;
        currentSkill = SkillDict[currentBtn];
        activateBtn.interactable = ButtonDict[currentBtn];
    }

    public void mainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void cancel()
    {
        skillanim.SetTrigger("SkillOut");
        backBtn.gameObject.SetActive(true);
    }

    public void activate(Button b)
    {
        SkillDict[b].isActive = true;
        skillanim.SetTrigger("SkillOut");
        backBtn.gameObject.SetActive(true);
        Image img = b.GetComponent<Image>();
        img.color = Color.green;
        i++;
    }
}
