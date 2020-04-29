using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile
{
	public string building;
	public List<Card> cardPile = new List<Card>();
	public List<ProfCard> profPile = new List<ProfCard>();
	public int size;

	public Attributes none = new Attributes(0, 0, 0, 0, 0);
	public Attributes acOne = new Attributes(1, 0, 0, 0, 0);
	public Attributes acTwo = new Attributes(2, 0, 0, 0, 0);
	public Attributes acThree = new Attributes(3, 0, 0, 0, 0);
	public Attributes acFive = new Attributes(5, 0, 0, 0, 0);
	public Attributes acTen = new Attributes(10, 0, 0, 0, 0);
	public Attributes acOnehOne = new Attributes(1, 0, 0, 0, 1);
	public Attributes sOne = new Attributes(0, 0, 1, 0, 0);
	public Attributes sTwo = new Attributes(0, 0, 2, 0, 0);
	public Attributes sThree = new Attributes(0, 0, 3, 0, 0);
	public Attributes hMinusOne = new Attributes(0, 0, 0, 0, -1);
	public Attributes hMinusTwo = new Attributes(0, 0, 0, 0, -2);
	public Attributes hMinusThree = new Attributes(0, 0, 0, 0, -3);
	public Attributes hOne = new Attributes(0, 0, 0, 0, 1);
	public Attributes hTwo = new Attributes(0, 0, 0, 0, 2);
	public Attributes hThree = new Attributes(0, 0, 0, 0, 3);
	public Attributes hTen = new Attributes(0, 0, 0, 0, 10);
	public Attributes arOne = new Attributes(0, 1, 0, 0, 0);
	public Attributes arTwo = new Attributes(0, 2, 0, 0, 0);
	public Attributes arThree = new Attributes(0, 3, 0, 0, 0);
	public Attributes arFour = new Attributes(0, 4, 0, 0, 0);
	public Attributes arFive = new Attributes(0, 5, 0, 0, 0);
	public Attributes arSix = new Attributes(0, 6, 0, 0, 0);
	public Attributes arSeven = new Attributes(0, 7, 0, 0, 0);
	public Attributes arEight = new Attributes(0, 8, 0, 0, 0);
	public Attributes arTen = new Attributes(0, 10, 0, 0, 0);
	public Attributes pOne = new Attributes(0, 0, 0, 1, 0);
	public Attributes pTwo = new Attributes(0, 0, 0, 2, 0);
	public Attributes pThree = new Attributes(0, 0, 0, 3, 0);
	public Attributes pFive = new Attributes(0, 0, 0, 5, 0);
	public Attributes acTwosOne = new Attributes(2, 0, 1, 0, 0);
	public Attributes acTwohOne = new Attributes(2, 0, 0, 0, 1);
	public Attributes acTwosTwohTwo = new Attributes(2, 0, 2, 0, 2);
	public Attributes sTwohTwo = new Attributes(0, 0, 2, 0, 2);
	public Attributes arTwohTwo = new Attributes(0, 2, 0, 0, 2);
	public Attributes sOnehTwo = new Attributes(0, 0, 1, 0, 2);
	public Attributes acTwoarTwohThree = new Attributes(2, 3, 0, 0, 3);
	public Attributes arOnehOne = new Attributes(0, 1, 0, 0, 1);
	public Attributes sMinusOnehMinusTwo = new Attributes(0, 0, -1, 0, -2);
	public Attributes sOnefTen = new Attributes(0, 0, 1, 0, 0);
	public Attributes fTwenty = new Attributes(0, 0, 0, 0, 0);
	public Attributes sThreefTwenty = new Attributes(0, 0, 3, 0, 0);
	public Attributes profTen = new Attributes(0, 0, 0, 0, 0);
	public Attributes acTwoarTwo = new Attributes(2, 2, 0, 0, 0);
	public Attributes arFivesThree = new Attributes(2, 2, 0, 0, 0);
	public Attributes artistTwentyFive = new Attributes(0, 0, 0, 0, 0);
	public Attributes artistThirtyFive = new Attributes(0, 0, 0, 0, 0);
	public Attributes arOnesOne = new Attributes(0, 1, 1, 0, 0);
	public Attributes profTwentyFive = new Attributes(0, 0, 0, 0, 0);
	public Attributes acThreeprofThirtyFive = new Attributes(3, 0, 0, 0, 0);
	public Attributes sOnepOnehOne = new Attributes(0, 0, 1, 1, 1);
	public Attributes sTwopTwohTwo = new Attributes(0, 0, 2, 2, 2);
	public Attributes pMinusOnehMinusTwo = new Attributes(0, 0, 0, -1, -2);
	public Attributes pOnehOne = new Attributes(0, 0, 0, 1, 1);
	public Attributes hMinusFive = new Attributes(0, 0, 0, 0, -5);

    CardPile()
    {
		createProf();
    }

    public void createProf()
    {
		profPile.Add(new ProfCard("Meireles Rui", "+2 academics for every lab session", "Combo: +5 academics for every lab session",
		acTwo, acFive, 0, "Lab"));
		profPile.Add(new ProfCard("Amitava Kumar", "+1 academics every time you go to Sunset Lake", "Combo: +3 academics every time you go to Sunset Lake",
		acOne, acThree, 1, "Sunset Lake"));
		profPile.Add(new ProfCard("Michael Joyce", "+1 academics every time you go to Vogelstein", "Combo: +3 academics every time you go to Vogelstein",
		acOne, acThree, 2, "Vogelstein"));
		profPile.Add(new ProfCard("Justin Patch", "+1 academics every time you go to Vogelstein", "Combo: +3 academics every time you go to Vogelstein",
		acOne, acThree, 3, "Vogelstein"));
	}

    public ProfCard pickProf()
    {
		int cardIndex = Random.Range(0, profPile.Count);
		return profPile[cardIndex];
	}

    public static CardPile createLib()
    {
		CardPile cp = new CardPile();
        cp.cardPile.Add(new Card("You studied so hard in the library that you feel smart afterwards.",
                "Academics +2", cp.acTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("You studied so hard in the library that you feel smart afterwards.",
                "Academics +2", cp.acTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("You were finishing your reading assignment but unfortunately fell asleep.",
                "Skip next turn", cp.none, "Skip", false, "Library"));
        cp.cardPile.Add(new Card("You were finishing your reading assignment but unfortunately fell asleep.",
                "Skip next turn", cp.none, "Skip", false, "Library"));
        cp.cardPile.Add(new Card("You visited the special collections and was blown away by the awesomeness by the archives.",
                "Academics +3", cp.acThree, "", false, "Library"));
        cp.cardPile.Add(new Card("You visited the special collections and was blown away by the awesomeness by the archives.",
                "Academics +3", cp.acThree, "", false, "Library"));
        cp.cardPile.Add(new Card("You were starring at Lady Cornaro’s figure, and she gave you a blessing, saying you can at least get an A- on your next test.",
                "Academics +1, Happiness +1", cp.acOnehOne, "", false, "Library"));
        cp.cardPile.Add(new Card("You were starring at Lady Cornaro’s figure, and she gave you a blessing, saying you can at least get an A- on your next test.",
                "Academics +1, Happiness +1", cp.acOnehOne, "", false, "Library"));
        cp.cardPile.Add(new Card("You were very clumsy and spilled water all over your homework.",
                "Happiness -2", cp.hMinusOne, "", false, "Library"));
        cp.cardPile.Add(new Card("You were very clumsy and spilled water all over your homework.",
                "Happiness -2", cp.hMinusOne, "", false, "Library"));
        cp.cardPile.Add(new Card("You met your friend from class, and you talked about how great the cookies were tonight.",
                "Social +2", cp.sTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("You met your friend from class, and you talked about how great the cookies were tonight.",
                "Social +2", cp.sTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("You formed a study group with your friends, and it paid off on the next exam.",
                "Academics +2, Social +1", cp.acTwosOne, "Study with friends", false, "Library"));
        cp.cardPile.Add(new Card("You formed a study group with your friends, and it paid off on the next exam.",
                "Academics +2, Social +1", cp.acTwosOne, "Study with friends", false, "Library"));
        cp.cardPile.Add(new Card("You meditated on the third floor, and you feel great, totally forgetting the exam you failed this morning.",
                "Happiness +2", cp.hTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("You meditated on the third floor, and you feel great, totally forgetting the exam you failed this morning.",
                "Happiness +2", cp.hTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("It’s a maze! You got lost in the library basement.",
                "Happiness -2", cp.hMinusTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("It’s a maze! You got lost in the library basement.",
                "Happiness -2", cp.hMinusTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("It's a maze! You got lost in the library basement, but you found your next favorite book.",
                "Happiness +1", cp.hOne, "", false, "Library"));
        cp.cardPile.Add(new Card("You went to the Q Center and got help for your homework assignment.",
                "Academics +2", cp.acTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("You went to the Q Center and got help for your homework assignment.",
                "Academics +2", cp.acTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("You went to the writing center and received constructive advice on your essay.",
                "Academics +2", cp.acTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("You went to the writing center and received constructive advice on your essay.",
                "Academics +2", cp.acTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("Great! You found a bunch of books that will help you with your essay, so you checked them all out.",
                "Academics +2", cp.acTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("Great! You found a bunch of books that will help you with your essay, so you checked them all out.",
                "Academics +2", cp.acTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("Oh no! You forgot to return the book you checked out a while ago.",
                "Happiness -2", cp.hMinusTwo, "", false, "Library"));
        cp.cardPile.Add(new Card("Oh no! You forgot to return the book you checked out a while ago.",
                "Happiness -2", cp.hMinusTwo, "", false, "Library"));
        cp.cardPile.Add(new ComboItem("Immigrant, Montana by Amitava Kumar",
                "Academics+10, Combo: +3 Academics every time you go to sunset lake", cp.acTen, cp.acThree, "Sunset Lake", 1));
        cp.cardPile.Add(new ComboItem("Disappearance by Michael Joyce",
                "Academics+10, +3 Academics every time you go to Vogelstein", cp.acTen, cp.acThree, "Vogelstein", 2));
        cp.cardPile.Add(new ComboItem("Terrior by Thomas Parker",
                "Academics+10, +3 Academics every time you go to Gordon Commons", cp.acTen, cp.acThree, "Deece", 3));
        cp.cardPile.Add(new ComboItem("Geometry from a Differentiable Viewpoint by John McCleary",
                "Academics+10, +3 Academics every time you go to Main", cp.acTen, cp.acThree, "Main", 4));
        return cp;
    }

    public static CardPile createMain()
	{
		CardPile cp = new CardPile();
        
		cp.cardPile.Add(new Card("It's Chili Wednesday! You had lunch at retreat with your friends.",
				"Social +2", cp.sTwo, "", false, "Main"));
		cp.cardPile.Add(new Card("It's Chili Wednesday! You had lunch at retreat with your friends.",
				"Social +2", cp.sTwo, "", false, "Main"));
		cp.cardPile.Add(new Card("It's Tasty Tuesday! You had some great tacos.",
				"Happiness +1", cp.hOne, "", false, "Main"));
		cp.cardPile.Add(new Card("It's Tasty Tuesday! You had some great curry.",
				"Happiness +1", cp.hOne, "", false, "Main"));
		cp.cardPile.Add(new Card("You read a book while savoring the sushi from Retreat.",
				"Academics+2, Happiness +1", cp.acTwohOne, "", false, "Main"));
		cp.cardPile.Add(new Card("You read a book while savoring the sushi from Retreat.",
				"Academics+2, Happiness +1", cp.acTwohOne, "", false, "Main"));
		cp.cardPile.Add(new Card("You wrote for the Miscellany News, and your readers loved your article!",
				"Academics+2, Happiness +2, Social +2", cp.acTwosTwohTwo, "", false, "Main"));
		cp.cardPile.Add(new Card("You went to Mug night, and you had a great time.",
				"Happiness +2, Social +2", cp.sTwohTwo, "", false, "Main"));
		cp.cardPile.Add(new Card("You went to Mug night, and you had a great time.",
				"Happiness +2, Social +2", cp.sTwohTwo, "", false, "Main"));
		cp.cardPile.Add(new Card("You went to Mug night. It was a crazy time, and you felt really sick afterwards ",
				"Physique -1, Happiness -2", cp.pMinusOnehMinusTwo, "Skip", false, "Main"));
		cp.cardPile.Add(new Card("You hung out with your friends and had a great time.",
				"Social +2", cp.sTwo, "", false, "Main"));
		cp.cardPile.Add(new Card("You hung out with your friends and had a great time.",
				"Social +2", cp.sTwo, "", false, "Main"));
		cp.cardPile.Add(new Card("You lost your mailbox key.",
				"Happiness -2", cp.hMinusTwo, "", false, "Main"));
		cp.cardPile.Add(new Card("You lost your mailbox key.",
				"Happiness -2", cp.hMinusTwo, "", false, "Main"));
		cp.cardPile.Add(new Card("You joined Run Vassar, and you will run every morning.",
				"Physique+5", cp.pFive, "", true, "Main"));
		cp.cardPile.Add(new Card("You went to a lecture in the rose parlor. It was a great talk.",
				"Academics +3", cp.acThree, "", false, "Main"));
		cp.cardPile.Add(new Card("You went to a lecture in the rose parlor. It was a great talk.",
				"Academics +3", cp.acThree, "", false, "Main"));
		cp.cardPile.Add(new Card("You went to a lecture in the rose parlor, but you felt asleep.",
				"Skip next turn", cp.none, "Skip", false, "Main"));
		cp.cardPile.Add(new Card("You went to the innovation lab and had a lot of fun with the 3D printer",
				"Academics +1, Happiness +1", cp.acOnehOne, "", false, "Main"));
		cp.cardPile.Add(new Card("You went to the innovation lab and had a lot of fun with the 3D printer",
				"Academics +1, Happiness +1", cp.acOnehOne, "", false, "Main"));
		return cp;
	}

    public static CardPile createGym()
    {
		CardPile cp = new CardPile();
		cp.cardPile.Add(new Card("You had a great workout, and you loved the way you look in the mirror.",
				"Physique +1", cp.pOne, "", false, "Gym"));
		cp.cardPile.Add(new Card("You had a great workout, and you loved the way you look in the mirror.",
				"Physique +1", cp.pOne, "", false, "Gym"));
		cp.cardPile.Add(new Card("You played pick-up basketball with your friends, and you hit the game-winning shot.",
				"Social +1, Physique +1, Happiness +1", cp.sOnepOnehOne, "", false, "Gym"));
		cp.cardPile.Add(new Card("You played an intramural sport and had a great time.",
				"Social +1, Physique +1, Happiness +1", cp.sOnepOnehOne, "", false, "Gym"));
		cp.cardPile.Add(new Card("You rolled your ankle trying to be Kyrie Irving.",
				"Physique -1, Happiness -2, Skip next turn", cp.pMinusOnehMinusTwo, "Skip", false, "Gym"));
		cp.cardPile.Add(new Card("You attempted an unsuccessful bicycle kick, and your back hurt for a week.",
				"Physique -1, Happiness -2, Skip next turn", cp.pMinusOnehMinusTwo, "Skip", false, "Gym"));
		cp.cardPile.Add(new Card("You scored an outrageous bicycle kick shot. Everyone is amazed.",
				"Happiness +3, Skip next turn", cp.pMinusOnehMinusTwo, "Skip", false, "Gym"));
		cp.cardPile.Add(new Card("You had a great swim in the pool.",
				"Physique +1", cp.pOne, "", false, "Gym"));
		cp.cardPile.Add(new Card("You had a great swim in the pool.",
				"Physique +1", cp.pOne, "", false, "Gym"));
		cp.cardPile.Add(new Card("You learned to play golf, and you’re proud of yourself.",
				"Physique +1, Happiness +1", cp.pOnehOne, "", false, "Gym"));
		cp.cardPile.Add(new Card("You hit a golf ball into the sunset lake, frightening the ducks.",
				"Happiness -5", cp.hMinusFive, "", true, "Gym"));
		cp.cardPile.Add(new Card("You walked all the way to the gym but found it’s closed.",
				"Happiness -2", cp.hMinusTwo, "", false, "Gym"));
		return cp;
	}

	public static CardPile createDeece()
	{
		CardPile cp = new CardPile();
		cp.cardPile.Add(new Card("You went to Late Night with your friends and had some mozz sticks!",
				"Social +1, you're a little closer to your friends", cp.sOnefTen, "", false, "Deece"));
		cp.cardPile.Add(new Card("You went to Late Night with your friends and had some mozz sticks!",
				"Social +1, you're a little closer to your friends", cp.sOnefTen, "", false, "Deece"));
		cp.cardPile.Add(new Card("Super-efficient! You finished the required reading while eating.",
				"Academics +2", cp.acTwo, "", false, "Deece"));
		cp.cardPile.Add(new Card("You finished the required reading while eating only to find later that you remembered nothing.",
				"Happiness -1", cp.hMinusOne, "", false, "Deece"));
		cp.cardPile.Add(new Card("You tried out a new recipe in 'Your Kitchen' and the tantalizing smell attracted many people.",
				"You are closer to your friends", cp.fTwenty, "", false, "Deece"));
		cp.cardPile.Add(new Card("You tried out a new recipe in 'Your Kitchen' and the tantalizing smell attracted many people.",
				"You are closer to your friends", cp.fTwenty, "", false, "Deece"));
		cp.cardPile.Add(new Card("Worth waiting! You loved the new Global Kitchen menu.",
				"Happiness +2", cp.hTwo, "", false, "Deece"));
		cp.cardPile.Add(new Card("Worth waiting! You loved the new Global Kitchen menu.",
				"Happiness +2", cp.hTwo, "", false, "Deece"));
		cp.cardPile.Add(new Card("Too salty! You put too much salt in the scrambled egg.",
				"Happiness -2", cp.hMinusTwo, "", false, "Deece"));
		cp.cardPile.Add(new Card("You had a great dinner with your friends.",
				"Social +3, You are closer to your friends", cp.sThreefTwenty, "", false, "Deece"));
		cp.cardPile.Add(new Card("You had a great dinner with your friends.",
				"Social +3, You are closer to your friends", cp.sThreefTwenty, "", false, "Deece"));
		cp.cardPile.Add(new Card("You ate with your professor and had a meaningful conversation.",
				"You are a little closer to your professor", cp.profTen, "", false, "Deece"));
		cp.cardPile.Add(new Card("You ate with your professor and had a meaningful conversation.",
				"You are a little closer to your professor", cp.profTen, "", false, "Deece"));
		cp.cardPile.Add(new Card("You had a quality study time on the 3rd floor.",
				"Academics +2", cp.acTwo, "", false, "Deece"));
		cp.cardPile.Add(new Card("You found the last untaken stall!",
				"Happiness +1", cp.hOne, "", false, "Deece"));
		cp.cardPile.Add(new Card("You put some cereal in the bowl, but found that there was no milk left.",
				"Happiness -1", cp.hMinusOne, "", false, "Deece"));
		cp.cardPile.Add(new Card("You witnessed someone take the last piece of cookie that you wanted.",
				"Happiness -1", cp.hMinusOne, "", false, "Deece"));
		cp.cardPile.Add(new Card("The day had come, you were tired of the Deece food.",
				"Happiness -1", cp.hMinusOne, "", false, "Deece"));
		return cp;
	}

	public static CardPile createDorm()
	{
		CardPile cp = new CardPile();
		cp.cardPile.Add(new Card("You swiped your card for laundry only to find that the broken washing machine ate your money.",
				"Happiness -1", cp.hMinusOne, "", false, "Dorm"));
		cp.cardPile.Add(new Card("Your roommate snored extremely loud and you couldn’t fall asleep.",
				"Happiness -1", cp.hMinusOne, "", false, "Dorm"));
		cp.cardPile.Add(new Card("Your roommate snored extremely loud and you couldn’t fall asleep.",
				"Happiness -1", cp.hMinusOne, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You studied with your friends in the MPR and you finished all your work.",
				"Academics+2, Happiness +1", cp.acTwohOne, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You studied with your friends in the MPR and you finished all your work.",
				"Academics+2, Happiness +1", cp.acTwohOne, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You studied with your friends in the MPR and you ended up chatting and had no work done.",
				"Happiness +2", cp.hTwo, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You had a wonderful night's sleep, and you woke up feeling refreshed.",
				"Happiness +1", cp.hOne, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You had a wonderful night's sleep, and you woke up feeling refreshed.",
				"Happiness +1", cp.hOne, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You felt sick after the party and threw up in the bathroom at the wellness section.",
				"Happiness -2", cp.hMinusTwo, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You played board games with your friends in the parlor and had a great time.",
				"Social+2, Happiness +2", cp.sTwohTwo, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You played video games with your friends in the parlor and had a great time.",
				"Social+2, Happiness +2", cp.sTwohTwo, "", false, "Dorm"));
		cp.cardPile.Add(new Card("The fire alarm went off at midnight! ",
				"Happiness -2", cp.hMinusTwo, "", false, "Dorm"));
		cp.cardPile.Add(new Card("The fire alarm went off at midnight! ",
				"Happiness -2", cp.hMinusTwo, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You dragged your broken bike to the Bike Shop at Strong’s basement and they fixed it in no time.",
				"Happiness +2", cp.hTwo, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You bought a bag of cookies from the vending machine and it got stuck. There was nothing you could do.",
				"Happiness -1", cp.hMinusOne, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You bought a bag of cookies from the vending machine and it got stuck. There was nothing you could do.",
				"Happiness -1", cp.hMinusOne, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You bought a bag of cookies from the vending machine and two bags dropped down!",
				"Happiness +2", cp.hTwo, "", false, "Dorm"));
		cp.cardPile.Add(new Card("Your friends arranged a surprise birthday party for you.",
				"Happiness +10", cp.hTen, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You practiced playing the piano in the parlor and made great progress.",
				"Art +2, Happiness +2", cp.arTwohTwo, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You practiced playing the piano in the parlor and made great progress.",
				"Art +2, Happiness +2", cp.arTwohTwo, "", false, "Dorm"));
		cp.cardPile.Add(new Card("Your radiator went off and it was freezing in your room.",
				"Happiness -1", cp.hMinusOne, "", false, "Dorm"));
		cp.cardPile.Add(new Card("You played pool with your friends in the basement, and you won every single game.",
				"Social +1, Happiness +2", cp.sOnehTwo, "", false, "Dorm"));
		cp.cardPile.Add(new Card("Just… One … More… Snooze…",
				"Happiness -1", cp.hMinusOne, "", false, "Dorm"));
		return cp;
	}

	public static CardPile createLoeb()
	{
		CardPile cp = new CardPile();
		cp.cardPile.Add(new Card("You went on a tour in the Loeb Center and loved the art collection.",
				"Art +1", cp.arOne, "", false, "Loeb"));
		cp.cardPile.Add(new Card("You went on a tour in the Loeb Center and loved the art collection.",
				"Art +1", cp.arOne, "", false, "Loeb"));
		cp.cardPile.Add(new Card("You starred at the Woman in Red Armchair for the entire afternoon, and you feel like an artist.",
				"Art +2", cp.arTwo, "", false, "Loeb"));
		cp.cardPile.Add(new Card("You starred at Through the Woods for the entire afternoon, and you feel like an artist.",
				"Art +2", cp.arTwo, "", false, "Loeb"));
		cp.cardPile.Add(new Card("Congratulations! You are hired as the tour guide at the Loeb Center.",
				"Academics +2, Art +3, Happiness +3", cp.acTwoarTwohThree, "", true, "Loeb"));
		cp.cardPile.Add(new Card("You went to the late night loeb for poetry night, and you had a great time.",
				"Art +1, Happiness +1", cp.arOnehOne, "", false, "Loeb"));
		cp.cardPile.Add(new Card("You went to the late night loeb for poetry night, and you had a great time.",
				"Art +1, Happiness +1", cp.arOnehOne, "", false, "Loeb"));
		cp.cardPile.Add(new Card("You were showing off your art knowledge to your friend but you got the artist’s name wrong.",
				"Social -1, Happiness -2", cp.sMinusOnehMinusTwo, "", false, "Loeb"));
		cp.cardPile.Add(new Card("You were showing off your art knowledge to your friend but you got the artist’s name wrong.",
				"Social -1, Happiness -2", cp.sMinusOnehMinusTwo, "", false, "Loeb"));
		cp.cardPile.Add(new Card("The Woman in Red Armchair by Pablo Picasso",
				"Art +10", cp.arTen, "Artwork", true, "Loeb"));
		cp.cardPile.Add(new Card("Through the Woods by Asher Brown Durand",
				"Art +5", cp.arFive, "Artwork", true, "Loeb"));
		cp.cardPile.Add(new Card("Woman with Parasol in the Snow by Momokawa Choki",
				"Art +8", cp.arEight, "Artwork", true, "Loeb"));
		cp.cardPile.Add(new Card("The Three Trees by Rembrandt van Rijn",
				"Art +8", cp.arEight, "Artwork", true, "Loeb"));
		cp.cardPile.Add(new Card("You explored the antiquity section of the museum, and you loved the artworks",
				"Art +1", cp.arOne, "", false, "Loeb"));
		cp.cardPile.Add(new Card("You explored the antiquity section of the museum, and you loved the artworks",
				"Art +1", cp.arOne, "", false, "Loeb"));
		cp.cardPile.Add(new Card("You explored the European section of the museum, and you loved the artworks",
				"Art +1", cp.arOne, "", false, "Loeb"));
		cp.cardPile.Add(new Card("You explored the European section of the museum, and you loved the artworks",
				"Art +1", cp.arOne, "", false, "Loeb"));
		cp.cardPile.Add(new Card("You explored the Asian section of the museum, and you loved the artworks",
				"Art +1", cp.arOne, "", false, "Loeb"));
		cp.cardPile.Add(new Card("You explored the Asian section of the museum, and you loved the artworks",
				"Art +1", cp.arOne, "", false, "Loeb"));
		cp.cardPile.Add(new Card("You explored the Modern section of the museum, and you loved the artworks",
				"Art +1", cp.arOne, "", false, "Loeb"));
		cp.cardPile.Add(new Card("You explored the Modern section of the museum, and you loved the artworks",
				"Art +1", cp.arOne, "", false, "Loeb"));
		return cp;
	}

	public static CardPile createSkinner()
    {
		CardPile cp = new CardPile();
		cp.cardPile.Add(new Card("You enrolled in a piano class!",
				"Academics +2, Art +2", cp.acTwoarTwo, "", true, "Skinner"));
		cp.cardPile.Add(new Card("You enrolled in a cello class!",
				"Academics +2, Art +2", cp.acTwoarTwo, "", true, "Skinner"));
		cp.cardPile.Add(new Card("You enrolled in a clarinet class!",
				"Academics +2, Art +2", cp.acTwoarTwo, "", true, "Skinner"));
		cp.cardPile.Add(new Card("You enrolled in a guitar class!",
				"Academics +2, Art +2", cp.acTwoarTwo, "", true, "Skinner"));
		cp.cardPile.Add(new Card("Congratulations! You are now a part of the Vassar devils!",
				"Art +5, Social +3", cp.arFivesThree, "", true, "Skinner"));
		cp.cardPile.Add(new Card("You practiced Fantaisie Impromptu for 5 hours in the practice room, and you’re exhausted.",
				"Art +6, Skip next turn", cp.arSix, "Skip", false, "Skinner"));
		cp.cardPile.Add(new Card("You practiced Clair de Lune for 3 hours in the practice room.",
				"Art +4", cp.arFour, "", false, "Skinner"));
		cp.cardPile.Add(new Card("You performed at a recital, and the audience loved it!",
				"You're closer to the artists.", cp.artistTwentyFive, "", false, "Skinner"));
		cp.cardPile.Add(new Card("You performed at a recital, and the audience loved it!",
				"You're closer to the artists.", cp.artistTwentyFive, "", false, "Skinner"));
		cp.cardPile.Add(new Card("You played the violin blindfolded at a concert, everyone was impressed!",
				"You're a lot closer to the artists", cp.artistThirtyFive, "", false, "Skinner"));
		cp.cardPile.Add(new Card("You’re feeling inspired, so you sat down in the practice room and wrote a song.",
				"Art +3", cp.arThree, "", false, "Skinner"));
		cp.cardPile.Add(new Card("You practiced really hard for your upcoming performance.",
				"Art +1", cp.arOne, "", false, "Skinner"));
		cp.cardPile.Add(new Card("You practiced really hard for your upcoming performance.",
				"Art +1", cp.arOne, "", false, "Skinner"));
		cp.cardPile.Add(new Card("You rehearsed with the chorus.",
				"Art +1, Social +1", cp.arOnesOne, "", false, "Skinner"));
		cp.cardPile.Add(new Card("You rehearsed with the chorus.",
				"Art +1, Social +1", cp.arOnesOne, "", false, "Skinner"));
		cp.cardPile.Add(new Card("A Love Supreme by John Coltrane",
				"Art +5", cp.arFive, "Music", true, "Skinner"));
		cp.cardPile.Add(new Card("Fantaisie Impromptu by Frédéric Chopin",
				"Art +5", cp.arFive, "Music", true, "Skinner"));
		cp.cardPile.Add(new Card("Clair de Lune by Claude Debussy",
				"Art +5", cp.arFive, "Music", true, "Skinner"));
		cp.cardPile.Add(new Card("Lieder ohne Worte by Felix Mendelssohn",
				"Art +5", cp.arFive, "Music", true, "Skinner"));
		cp.cardPile.Add(new Card("Nevermind by Nirvana",
				"Art +5", cp.arFive, "Music", true, "Skinner"));
		return cp;
	}

	public static CardPile createBridge()
	{
		CardPile cp = new CardPile();
		cp.cardPile.Add(new Card("You hung out with your friends at the Bridge cafe.",
				"Social +3", cp.sThree, "", false, "Bridge"));
		cp.cardPile.Add(new Card("You hung out with your friends at the Bridge cafe.",
				"Social +3", cp.sThree, "", false, "Bridge"));
		cp.cardPile.Add(new Card("You had lunch with your professor at the Bridge cafe and had a great discussion on quantum mechanics.",
				"You are closer to your professors", cp.profTwentyFive, "", false, "Bridge"));
		cp.cardPile.Add(new Card("You had lunch with your professor at the Bridge cafe and had a great discussion on quantum mechanics.",
				"You are closer to your professors", cp.profTwentyFive, "", false, "Bridge"));
		cp.cardPile.Add(new Card("You went to a lab session, and invented a solution that cleans everything.",
				"Academics +3.You are a lot closer to your professors", cp.acThreeprofThirtyFive, "Lab", true, "Bridge"));
		cp.cardPile.Add(new Card("You went to a lab session, and discovered a type of ink that automatically writes the correct answer.",
				"Academics +3.You are a lot closer to your professors", cp.acThreeprofThirtyFive, "Lab", true, "Bridge"));
		cp.cardPile.Add(new Card("You went to a lab session, and discovered a new type of frog that turns itself into a squirrel in the day.",
				"Academics +3.You are a lot closer to your professors", cp.acThreeprofThirtyFive, "Lab", true, "Bridge"));
		cp.cardPile.Add(new Card("You went to a lab session, and discovered a way to turn solar power into matcha ice cream.",
				"Academics +3.You are a lot closer to your professors", cp.acThreeprofThirtyFive, "Lab", true, "Bridge"));
		cp.cardPile.Add(new Card("You went to a lab session, and your professor is very pleased with your work.",
				"You are closer to your professors", cp.profTwentyFive, "Lab", false, "Bridge"));
		cp.cardPile.Add(new Card("You went to a lab session, and your professor is very pleased with your work.",
				"You are closer to your professors", cp.profTwentyFive, "Lab", false, "Bridge"));
		cp.cardPile.Add(new Card("You went to a lab session, and things went kaboom.",
				"Happiness -3", cp.hMinusThree, "Lab", false, "Bridge"));
		cp.cardPile.Add(new Card("You went to a lab session, and things went kaboom.",
				"Happiness -3", cp.hMinusThree, "Lab", false, "Bridge"));
		cp.cardPile.Add(new Card("You studied with your friends while enjoying a cup of latte.",
				"Academics +2, Social +1", cp.acTwosOne, "", false, "Bridge"));
		cp.cardPile.Add(new Card("You studied with your friends while enjoying a cup of latte.",
				"Academics +2, Social +1", cp.acTwosOne, "", false, "Bridge"));
		cp.cardPile.Add(new Card("You studied for your upcoming exam while enjoying a cup of espresso.",
				"Academics +3", cp.acThree, "", false, "Bridge"));
		cp.cardPile.Add(new Card("You studied for your upcoming exam while enjoying a cup of espresso.",
				"Academics +3", cp.acThree, "", false, "Bridge"));
		cp.cardPile.Add(new Card("You had lunch with your professor at the Bridge cafe and had a great discussion on evolution.",
				"You're closer to your professors", cp.profTwentyFive, "", false, "Bridge"));
		cp.cardPile.Add(new Card("You had a great conversation with your professor after class.",
				"You're a little closer to your professors", cp.profTen, "", false, "Bridge"));
		cp.cardPile.Add(new Card("You had a great conversation with your professor after class.",
				"You're a little closer to your professors", cp.profTen, "", false, "Bridge"));
		cp.cardPile.Add(new Card("You had a great conversation with your professor after class.",
				"You're a little closer to your professors", cp.profTen, "", false, "Bridge"));
		cp.cardPile.Add(new Card("You had a great conversation with your professor after class.",
				"You're a little closer to your professors", cp.profTen, "", false, "Bridge"));
		return cp;
	}


	public Card pick()
	{
		int cardIndex = Random.Range(0, cardPile.Count) ;
		return cardPile[cardIndex];
	}
}

