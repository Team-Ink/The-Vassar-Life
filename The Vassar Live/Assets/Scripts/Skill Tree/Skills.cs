using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill
{
    public string name;
    public string description;
    //bonus
    public bool isUnlocked;
    public bool isActive;
    public SkillEffect se;

    public Skill(string name, string description, SkillEffect se)
    {
        this.name = name;
        this.description = description;
        isUnlocked = false;
        isActive = false;
        this.se = se;
    }
}
 

//Multipliers (manipuate the multiplier fields)
//Gives cards (artwork, prof)
//Unlock buildings
//class skillEffect is the parent of these 3 functionalities