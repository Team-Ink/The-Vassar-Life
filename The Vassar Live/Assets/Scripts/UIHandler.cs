using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIHandler : MonoBehaviour
{
    static Attributes points = new Attributes(0, 0, 0, 0, 5);
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

    public Dictionary<string, CardPile> cdb = new Dictionary<string, CardPile>();
    public Dictionary<string, Attributes> profBonusDict = new Dictionary<string, Attributes>();
    public Dictionary<string, Sprite> buildingSprite = new Dictionary<string, Sprite>();
    public Sprite[] profSprites = new Sprite [10];

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
        cdb.Add("Library", CardPile.createLib());
        cdb.Add("Main", CardPile.createMain());
        cdb.Add("Deece", CardPile.createDeece());
        cdb.Add("Loeb", CardPile.createLoeb());
        cdb.Add("Skinner", CardPile.createSkinner());
        cdb.Add("Dorm", CardPile.createDorm());
        cdb.Add("Bridge", CardPile.createBridge());
        cdb.Add("Gym", CardPile.createGym());
    }

    public void initProfBonusDict()
    {
        profBonusDict.Add("Lab", new Attributes(0, 0, 0, 0, 0));
        profBonusDict.Add("Main", new Attributes(0, 0, 0, 0, 0));
        profBonusDict.Add("Skinner", new Attributes(0, 0, 0, 0, 0));
        profBonusDict.Add("Loeb", new Attributes(0, 0, 0, 0, 0));
        profBonusDict.Add("Deece", new Attributes(0, 0, 0, 0, 0));
        profBonusDict.Add("Dorm", new Attributes(0, 0, 0, 0, 0));
        profBonusDict.Add("Sunset Lake", new Attributes(0, 0, 0, 0, 0));
        profBonusDict.Add("Direct", new Attributes(0, 0, 0, 0, 0));
    }
    void Start()
    {
        initCdb();
        initProfBonusDict();
        initBuildingSprite();
        initProfSprites();
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
        }
        else
        {
            cardType = 1;
            anim.SetTrigger("Entry");
            cardImage.sprite = buildingSprite[building];    
            cardContent.text = c.description;
            cardEffect.text = c.effect;
            NextButton.gameObject.SetActive(true);
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
        /*
        Card randomCard;
        randomCard = cdb["Library"].pick();
        if (randomCard is ProfCard)
        {
            // card type 2 = professor cards
            cardType = 2;
            switch (randomCard.name)
            {
                case "Meireles Rui":
                    profCardImage.sprite = profCardSprite;
                    profImage.sprite = RuiSprite;
                    profName.text = "Meireles Rui";
                    profBonus.text = "+2 academics for every lab session";
                    profCombo.text = "Combo: +5 academics for every lab session";
                    profAnim.SetTrigger("profEntry");
                    NextButton.gameObject.SetActive(true);
                    if (comboSet.Contains(1))
                        labBonus.AC = labBonus.AC + 5;
                    else
                    {
                        labBonus.AC = labBonus.AC + 2;
                        comboScet.Add(1);
                    }
                    break;
                case "Justin Patch":
                    break;
                    //so on and so forth

            }
        }
        else
        {
            cardType = 1;
            cardImage.sprite = librarySprite;
            anim.SetTrigger("Entry");
            cardContent.text = randomCard.description;
            cardEffect.text = randomCard.effect;
            NextButton.gameObject.SetActive(true);
            processPile(randomCard);

    */
        
    }

    void PickMain()
    {
        PickBuilding("Main");
        /*
        Card randomCard;
        randomCard = main.pick();
        if (randomCard is ProfCard)
        {
            cardType = 2;
            switch (randomCard.name)
            {
                case "Meireles Rui":
                    profCardImage.sprite = profCardSprite;
                    profImage.sprite = RuiSprite;
                    profName.text = "Meireles Rui";
                    profBonus.text = "+2 academics for every lab session";
                    profCombo.text = "Combo: +5 academics for every lab session";
                    profAnim.SetTrigger("profEntry");
                    NextButton.gameObject.SetActive(true);
                    if (comboSet.Contains(1))
                        labBonus.AC = labBonus.AC + 5;
                    else
                    {
                        labBonus.AC = labBonus.AC + 2;
                        comboSet.Add(1);
                    }
                    break;
                case "Justin Patch":
                    break;
                    //so on and so forth

            }
        }
        else
        {
            cardType = 1;
            cardImage.sprite = mainSprite;
            anim.SetTrigger("Entry");
            cardContent.text = randomCard.description;
            cardEffect.text = randomCard.effect;
            NextButton.gameObject.SetActive(true);
            processPile(randomCard);
        }
        */
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
        Debug.Log(i);
        profCardImage.sprite = profCardSprite;
        profName.text = pc.name;
        profBonus.text = pc.effect;
        profCombo.text = pc.profBonus;
        profImage.sprite = profSprites[i];
        profAnim.SetTrigger("profEntry");
        NextButton.gameObject.SetActive(true);
        //if the combo is not completed add the professor's points to bonus
        if (comboSet.Contains(i))
        {
            profBonusDict[pc.bonusType].addAttributes(pc.combo);
            
        }
        else
        {
            profBonusDict[pc.bonusType].addAttributes(pc.bonus);
            comboSet.Add(i);
        }
        if (pc.bonusType.Equals("Direct"))
        {
            AddScore(profBonusDict["Direct"]);
            profBonusDict["Direct"] = new Attributes(0,0,0,0,0);
            }
    }
}

//update method that works for every card

