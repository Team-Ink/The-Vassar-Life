using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIHandler : MonoBehaviour
{
    public static Attributes points = new Attributes(0, 0, 0, 0, 5);
    static Attributes labBonus = new Attributes(0, 0, 0, 0, 0);
    static Attributes sunsetLakeBonus = new Attributes(0, 0, 0, 0, 0);
    static Attributes mainBonus = new Attributes(0, 0, 0, 0, 0);
    static Attributes Bonus = new Attributes(0, 0, 0, 0, 0);
    HashSet<int> comboSet = new HashSet<int>();
    //using enums instead of int
    int cardType;
    double ac = points.AC;
    double ar = points.AR;
    double s = points.S;
    double p = points.P;
    double h = points.H;
    int turn = 0;
    double multiplier = 1.0;
    #region UIFields
    [SerializeField]
    public Button LibraryButton;
    [SerializeField]
    public Button NextButton;
    [SerializeField]
    public Button MainButton;
    [SerializeField]
    public Button DormButton;
    [SerializeField]
    public Button SkinnerButton;
    [SerializeField]
    public Button BridgeButton;
    [SerializeField]
    public Button GordonCommonsButton;
    [SerializeField]
    public Button LoebButton;
    [SerializeField]
    public Button GymButton;
    [SerializeField]
    public Button VogelsteinButton;
    [SerializeField]
    public Button LibraryLbl;
    [SerializeField]
    public Button MainLbl;
    [SerializeField]
    public Button SkinnerLbl;
    [SerializeField]
    public Button BridgeLbl;
    [SerializeField]
    public Button GordonCommonsLbl;
    [SerializeField]
    public Button LoebLbl;
    [SerializeField]
    public Button GymLbl;
    [SerializeField]
    public Button VogelsteinLbl;
    [SerializeField]
    public Text buildingName;
    [SerializeField]
    public Text cardContent;
    [SerializeField]
    public Text cardEffect;
    public Image cardImage;
    public Image profCardImage;
    [SerializeField]
    public Sprite librarySprite;
    [SerializeField]
    public Sprite mainSprite;
    [SerializeField]
    public Sprite dormSprite;
    [SerializeField]
    public Sprite skinnerSprite;
    [SerializeField]
    public Sprite bridgeSprite;
    [SerializeField]
    public Sprite gcSprite;
    [SerializeField]
    public Sprite loebSprite;
    [SerializeField]
    public Sprite gymSprite;
    public Animator anim;
    [SerializeField]
    public Text profName;
    [SerializeField]
    public Text profBonus;
    [SerializeField]
    public Text profCombo;
    [SerializeField]
    public Sprite profCardSprite;
    [SerializeField]
    public Image profImage;
    [SerializeField]
    public Sprite RuiSprite;
    [SerializeField]
    public Sprite KumarSprite;
    public Animator profAnim;

    [SerializeField]
    public Text ACScore;
    [SerializeField]
    public Text ARScore;
    [SerializeField]
    public Text SScore;
    [SerializeField]
    public Text PScore;
    [SerializeField]
    public Text HScore;
    #endregion

    public Dictionary<string, CardPile> cdb = new Dictionary<string, CardPile>();
    public Dictionary<string, Attributes> BonusDict = new Dictionary<string, Attributes>();
    public Dictionary<string, Attributes> MultiplierDict = new Dictionary<string, Attributes>();
    public Dictionary<string, Sprite> buildingSprite = new Dictionary<string, Sprite>();
    public Dictionary<string, bool> unlockDict = new Dictionary<string, bool>();
    public Sprite[] profSprites = new Sprite [10];

    #region Initialization
    public void initBuildingSprite()
    {
        buildingSprite.Add("Bridge", bridgeSprite);
        buildingSprite.Add("Main", mainSprite);
        buildingSprite.Add("Skinner", skinnerSprite);
        buildingSprite.Add("Deece", gcSprite);
        buildingSprite.Add("Library", librarySprite);
        buildingSprite.Add("Gym", gymSprite);
        buildingSprite.Add("Loeb", loebSprite);
        buildingSprite.Add("Dorm", dormSprite);
    }
    public void initProfSprites()
    {
        profSprites[0] = RuiSprite;
        profSprites[1] = KumarSprite;
    }

    public void initCdb()
    {
        //loop for the buildings
        cdb.Add("Library", CardPile.createLib());
        cdb.Add("Main", CardPile.createMain());
        cdb.Add("Deece", CardPile.createDeece());
        cdb.Add("Loeb", CardPile.createLoeb());
        cdb.Add("Skinner", CardPile.createSkinner());
        cdb.Add("Dorm", CardPile.createDorm());
        cdb.Add("Bridge", CardPile.createBridge());
        cdb.Add("Gym", CardPile.createGym());
    }

    public void initBonusDict()
    {
        BonusDict.Add("Lab", new Attributes(0, 0, 0, 0, 0));
        BonusDict.Add("Main", new Attributes(0, 0, 0, 0, 0));
        BonusDict.Add("Skinner", new Attributes(0, 0, 0, 0, 0));
        BonusDict.Add("Loeb", new Attributes(0, 0, 0, 0, 0));
        BonusDict.Add("Deece", new Attributes(0, 0, 0, 0, 0));
        BonusDict.Add("Dorm", new Attributes(0, 0, 0, 0, 0));
        BonusDict.Add("Sunset Lake", new Attributes(0, 0, 0, 0, 0));
        BonusDict.Add("Direct", new Attributes(0, 0, 0, 0, 0));
    }

    public void initMultiplierDict()
    {
        MultiplierDict.Add("Lab", new Attributes(1, 1, 1, 1, 1));
        MultiplierDict.Add("Main", new Attributes(1, 1, 1, 1, 1));
        MultiplierDict.Add("Skinner", new Attributes(1, 1, 1, 1, 1));
        MultiplierDict.Add("Loeb", new Attributes(1, 1, 1, 1, 1));
        MultiplierDict.Add("Deece", new Attributes(1, 1, 1, 1, 1));
        MultiplierDict.Add("Dorm", new Attributes(1, 1, 1, 1, 1));
        MultiplierDict.Add("Sunset Lake", new Attributes(1, 1, 1, 1, 1));
    }

    public void initUnlockDict()
    {
        unlockDict.Add("Main", true);
        unlockDict.Add("Library", true);
        unlockDict.Add("Gym", true);
        unlockDict.Add("Skinner", false);
        unlockDict.Add("Vogelstein", false);
        unlockDict.Add("VarsityPractice", false);
        unlockDict.Add("Loeb", true);
        unlockDict.Add("Deece", false);
        unlockDict.Add("Dorm", true);
        unlockDict.Add("Sunset Lake", false);
    }
    #endregion

    void Start()
    {
        //make sure all the dictionaries are initialized
        initCdb();
        initBonusDict();
        initBuildingSprite();
        initProfSprites();
        initMultiplierDict();
        cardImage = GameObject.Find("CardTemplate").GetComponent<Image>();
        profCardImage = GameObject.Find("ProfCardTemplate").GetComponent<Image>();
        profImage = GameObject.Find("Image").GetComponent<Image>();
        LibraryButton.onClick.AddListener(PickLibrary);
        MainButton.onClick.AddListener(PickMain);
        DormButton.onClick.AddListener(PickDorm);
        SkinnerButton.onClick.AddListener(PickSkinner);
        BridgeButton.onClick.AddListener(PickBridge);
        GordonCommonsButton.onClick.AddListener(PickGordonCommons);
        LoebButton.onClick.AddListener(PickLoeb);
        GymButton.onClick.AddListener(PickGym);
        anim = GameObject.Find("CardTemplate").GetComponent<Animator>();
        profAnim = GameObject.Find("ProfCardTemplate").GetComponent<Animator>();
        NextButton.gameObject.SetActive(false);
        NextButton.onClick.AddListener(cardExit);
    }

    void Update()
    {

    }

    void PickBuilding(string building)
    {
        Card c = cdb[building].pick();
        if (c is ProfCard)
        {
            processProf((ProfCard)c);
            cdb[building].cardPile.Remove(c);
        }
        else
        {
            cardType = 1;
            anim.SetTrigger("Entry");
            cardImage.sprite = buildingSprite[building];    
            cardContent.text = c.description;
            cardEffect.text = c.effect;
            NextButton.gameObject.SetActive(true);
            if (c is ComboItem)
            {
                int i = ((ComboItem)c).index;
                if (comboSet.Contains(i))
                {
                    BonusDict[((ComboItem)c).comboType].addAttributes(((ComboItem)c).combo);
                }
                else
                {
                    AddScore(c);
                    updatePoints();
                    comboSet.Add(i);
                }
                cdb[building].cardPile.Remove(c);
            }
            processPile(c);
            if (c.isRemovable)
                cdb[building].cardPile.Remove(c);
            disableButtons();
        }
    }

    void cardExit()
    {
     if(cardType == 1)
        anim.SetTrigger("Exit");
     else if(cardType ==2)
        profAnim.SetTrigger("profExit");
        NextButton.gameObject.SetActive(false);
        enableButtons();
    }

    void PickLibrary()
    {
        PickBuilding("Library");
       
        
    }

    void PickMain()
    {
        PickBuilding("Main");
       
    }

    void PickDorm()
    {
        PickBuilding("Dorm");
    }

    void PickSkinner()
    {
        PickBuilding("Skinner");
    }

    void PickBridge()
    {
        PickBuilding("Bridge");

    }

    void PickGordonCommons()
    {
        PickBuilding("Deece");

    }

    void PickLoeb()
    {
        PickBuilding("Loeb");

    }

    void PickGym()
    {
        PickBuilding("Gym");

    }

    void updatePoints()
    {
        ACScore.text = ac.ToString();
        ARScore.text = ar.ToString();
        SScore.text = s.ToString();
        PScore.text = p.ToString();
        HScore.text = h.ToString();
    }

    public void AddScore(Card c)
    {
        ac += c.att.AC * multiplier;
        ar += c.att.AR * multiplier;
        s += c.att.S * multiplier;
        p += c.att.P * multiplier;
        h += c.att.H;
    }

    public void AddScore (Attributes att)
    {
        ac += att.AC * multiplier;
        ar += att.AR * multiplier;
        s += att.S * multiplier;
        p += att.P * multiplier;
        h += att.H;
    }

    private void disableButtons()
    {
        MainButton.interactable = false;
        LibraryButton.interactable = false;
        LoebButton.interactable = false;
        BridgeButton.interactable = false;
        DormButton.interactable = false;
        GymButton.interactable = false;
        SkinnerButton.interactable = false;
        GordonCommonsButton.interactable = false;
        MainLbl.interactable = false;
        LibraryLbl.interactable = false;
        LoebLbl.interactable = false;
        BridgeLbl.interactable = false;
        VogelsteinButton.interactable = false;
        GymLbl.interactable = false;
        SkinnerLbl.interactable = false;
        GordonCommonsLbl.interactable = false;
        VogelsteinLbl.interactable = false;
    }

    private void enableButtons()
    {
        MainButton.interactable = true;
        LibraryButton.interactable = true;
        LoebButton.interactable = true;
        BridgeButton.interactable = true;
        DormButton.interactable = true;
        GymButton.interactable = true;
        SkinnerButton.interactable = true;
        GordonCommonsButton.interactable = true;
        MainLbl.interactable = true;
        LibraryLbl.interactable = true;
        LoebLbl.interactable = true;
        BridgeLbl.interactable = true;
        VogelsteinButton.interactable = true;
        GymLbl.interactable = true;
        SkinnerLbl.interactable = true;
        GordonCommonsLbl.interactable = true;
        VogelsteinLbl.interactable = true;
    }

    public void processPile(Card randomCard)
    {
        //if (turn >= 30)
        //    endGame();
        //else
        // {
        if (h <= -10)
            multiplier = 0.25;
        else if (h < 0)
            multiplier = 0.5;
        else if (h < 20 && h >= 0)
            multiplier = 1;
        else if (h >= 20)
            multiplier = 1.2;
        else if (h >= 50)
            multiplier = 1.5;
        else if (h >= 75)
            multiplier = 2;
        AddScore(randomCard);
        updatePoints();
        if (randomCard.note.Equals("Skip"))
        {
            turn++;
        }
        turn++;
    }


    public void processProf (ProfCard pc)
    {
        //update the professor's image
        cardType = 2;
        int i = pc.index;
        profCardImage.sprite = profCardSprite;
        profName.text = pc.name;
        profBonus.text = pc.effect;
        profCombo.text = pc.profBonus;
        profImage.sprite = profSprites[i];
        profAnim.SetTrigger("profEntry");
        NextButton.gameObject.SetActive(true);
        disableButtons();
        //if the combo is not completed add the professor's points to bonus
        if (comboSet.Contains(i))
        {
            BonusDict[pc.bonusType].addAttributes(pc.combo);
            
        }
        else
        {
            BonusDict[pc.bonusType].addAttributes(pc.bonus);
            comboSet.Add(i);
        }
        if (pc.bonusType.Equals("Direct"))
        {
            AddScore(BonusDict["Direct"]);
            BonusDict["Direct"] = new Attributes(0,0,0,0,0);
            }
    }
}


