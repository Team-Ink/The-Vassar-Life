using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAs : SkillEffect
{
    public Attributes att;
    public UIHandler uh;
    public string point1;
    public string point2;
    public string building;
    public double multiplier = 1;

    public PointAs(string point1, string point2, string building)
    {
        this.point1 = point1;
        this.point2 = point2;
        this.building = building;
    }

    public PointAs(string point1, string point2, double multiplier, string building)
    {
        this.point1 = point1;
        this.point2 = point2;
        this.multiplier = multiplier;
        this.building = building;

    }

    public void skillActive()
    {
        if ((!(uh.currentCard is ProfCard))&& (!(uh.currentCard is ComboItem))
            && uh.currentCard.building.Equals(building))
        {

            uh.currentCard.att.attDict[point2] = uh.currentCard.att.attDict[point1] * multiplier;
        }
        
    }
}
