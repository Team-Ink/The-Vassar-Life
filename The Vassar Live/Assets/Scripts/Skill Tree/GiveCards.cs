using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCards : SkillEffect
{
    public string building;
    public int n;
    public UIHandler uh;

    public GiveCards(string building, int n)
    {
        this.building = building;
        this.n = n;
    }

    public void skillActive()
    {
        while (n > 0)
        {
            uh.PickBuilding(building);
            n--;
        }
    }
}
