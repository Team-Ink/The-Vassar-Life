using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfPool :CardPile
{
    public List<ProfCard> profs = new List<ProfCard>();

    public ProfPool()
    {
        profs.Add(new ProfCard("Meireles Rui", "+2 academics for every lab session", "Combo: +5 academics for every lab session",
            acTwo, acFive, 1, "Lab"));
        profs.Add(new ProfCard("Amitava Kumar", "+1 academics every time you go to Sunset Lake.", "Combo: +3 academics every time you go to sunset lake.",
            acOne, acThree, 2, "SunsetLake"));
        profs.Add(new ProfCard("Justin Patch", "+1 academics every time you go to Skinner Hall.", "Combo: gives Academics the equivalent of Art when drawn a music piece.",
           acOne, acThree, 3, "Skinner"));
        size = profs.Count;
    }
}
