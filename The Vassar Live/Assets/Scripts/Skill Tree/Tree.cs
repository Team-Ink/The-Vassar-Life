using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour
//consider using subclasses for different trees
{
    #region Buttons
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
    public  Button BFB;
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
    #endregion

    #region social Skill
    Skill UnlockDeece = new Skill("Unlock Deece", "Unlocks the Gordon Commons.");
    Skill GroupStudySkill = new Skill("Group Study Skill", "Gain 1.5x Academic points in Main.");
    Skill QuadPicnic = new Skill("Quad Picnic", "Gain 1.5x Happiness in Dorm.");
    Skill MugNight = new Skill("Mug Night Over Moodle", "From this point onward, gain half academic points,  but gain 3x social points");
    Skill DeeceCaffine = new Skill("Fueled By Deece Caffine", "Every time the player visits Deece, their next turn (after visiting deece) allows player to draw 3 cards");
    Skill TheMidnightScream = new Skill("The Midnight Scream and Joss Beach Pancakes", "Re-energize during finals weeks with screams and pancakes and friendship. You have a newfound spirit of determination. Gain 2x social and 2x academics");
    //but we don't have burger fi??
    Skill BurgerFiBros = new Skill("BurgerFi Bros", "After experiencing burgerfi, the next 3 turns have a bonus of 2x all points, but player cannot visit Deece");
    Skill ScenicHudsonValley = new Skill("Scenic Hudson Valley", "Unlocks Sunset Lake");
    Skill SusanSteinShiva = new Skill("Devoted to Susan Stein Shiva", "Gain the same amount in social points when gaining art points");
    Skill OfficiallyABrewer = new Skill("Officially a Brewer", "Gain the same amount in social points when gaining athletic points");
    Skill DeeceWithTheTeam = new Skill("Deece With the Team", "Gain 4x happiness at Deece");
    Skill LeaderofTheater = new Skill("Leader of Theater", "Gain 2.5x art at Vogelstein");
    #endregion



    int[] treeLevels = { 15, 35, 60, 90, 120 };
    Dictionary<Button, Skill> SkillDict = new Dictionary<Button, Skill>();

    Node SrootNode;

    void initSkillDict()
    {
        SkillDict.Add(root, UnlockDeece);
        SkillDict.Add(GSS, GroupStudySkill);
        SkillDict.Add(QP, QuadPicnic);
        SkillDict.Add(MN, MugNight);
        SkillDict.Add(DC, DeeceCaffine);
        SkillDict.Add(TMS, TheMidnightScream);
        SkillDict.Add(BFB, BurgerFiBros);
        SkillDict.Add(SHV, ScenicHudsonValley);
        SkillDict.Add(SSS, SusanSteinShiva);
        SkillDict.Add(OAB, OfficiallyABrewer);
        SkillDict.Add(DWTT, DeeceWithTheTeam);
        SkillDict.Add(LOT, LeaderofTheater);
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
        foreach(KeyValuePair<Button,Skill> s in SkillDict)
        {
            s.Key.onClick.AddListener(delegate{activate(s.Key);});
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
        Node BFBNode = new Node(BurgerFiBros);
        Node SHVNode = new Node(ScenicHudsonValley);
        Node SSSNode = new Node(SusanSteinShiva);
        Node OABNode = new Node(OfficiallyABrewer);
        Node DWTTNode = new Node(DeeceWithTheTeam);
        Node LOTNode = new Node(LeaderofTheater);
        SrootNode.addChild(GSSNode);
        SrootNode.addChild(QPNode);
        GSSNode.addChild(MNNode);
        GSSNode.addChild(DCNode);
        GSSNode.addChild(BFBNode);
        DCNode.addChild(TMSNode);
        BFBNode.addChild(SHVNode);
        QPNode.addChild(BFBNode);
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
            if (curr.skill.isActive)
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
        if (UnlockDeece.isActive)
            root.interactable = false;
        if (!GroupStudySkill.isActive)
            GSS.interactable = GroupStudySkill.isUnlocked;
        else
        {
            GSS.interactable = false;
            //Text text = GSS.GetComponent<Text>();
            //text.text = "active";
        }
        if (!QuadPicnic.isActive)
            QP.interactable = QuadPicnic.isUnlocked;
        else
        {
            QP.interactable = false;
            //Text text = QP.GetComponent<Text>();
            //text.text = "active";
        }
        if (!MugNight.isActive)
            MN.interactable = MugNight.isUnlocked;
        else
        {
            MN.interactable = false;
            //Text text = MN.GetComponent<Text>();
            //text.text = "active";
        }
        if (!DeeceCaffine.isActive)
            DC.interactable = DeeceCaffine.isUnlocked;
        else {
            DC.interactable = false;
            //Text text = DC.GetComponent<Text>();
            //text.text = "active";
        }
        if (!TheMidnightScream.isActive)
            TMS.interactable = TheMidnightScream.isUnlocked;
        else
        {
            TMS.interactable = false;
            //Text text = TMS.GetComponent<Text>();
            //text.text = "active";
        }
        if (!BurgerFiBros.isActive)
            BFB.interactable = BurgerFiBros.isUnlocked;
        else
        {
            BFB.interactable = false;
            //Text text = BFB.GetComponent<Text>();
            //text.text = "Active";
        }
        if (!ScenicHudsonValley.isActive)
            SHV.interactable = ScenicHudsonValley.isUnlocked;
        else
        {
            SHV.interactable = false;
            //Text text = SHV.GetComponent<Text>();
            //text.text = "active";
        }
        if (!SusanSteinShiva.isActive)
            SSS.interactable = SusanSteinShiva.isUnlocked;
        else
        {
            SSS.interactable = false;
            //Text text = SSS.GetComponent<Text>();
            //text.text = "active";
        }
        if (!OfficiallyABrewer.isActive)
            OAB.interactable = OfficiallyABrewer.isUnlocked;
        else
        {
            OAB.interactable = false;
            //Text text = OAB.GetComponent<Text>();
            //text.text = "active";
        }
        if (!DeeceWithTheTeam.isActive)
            DWTT.interactable = DeeceWithTheTeam.isUnlocked;
        else
        {
            DWTT.interactable = false;
            //Text text = DWTT.GetComponent<Text>();
            //text.text = "active";
        }
        if (!LeaderofTheater.isActive)
            LOT.interactable = LeaderofTheater.isUnlocked;
        else
        {
            LOT.interactable = false;
            //Text text = LOT.GetComponent<Text>();
            //text.text = "active";
        }
    }
    public void activate(Button b)
    {
        Image img = b.GetComponent<Image>();
        img.color = Color.green;
        //text.text = "active";
        SkillDict[b].isActive = true;
    }
}
