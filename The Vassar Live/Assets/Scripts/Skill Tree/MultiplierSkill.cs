using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierSkill: SkillEffect
{
    public Attributes multiplier;
    public string multiplierType;
    UIHandler uh;

    public MultiplierSkill(Attributes multiplier, string multiplierType)
    {
        this.multiplier = multiplier;
        this.multiplierType = multiplierType;
    }

    public void skillActive()
    {
        uh.MultiplierDict[multiplierType]= uh.MultiplierDict[multiplierType].multiplyAttributes(multiplier);
    }
}
