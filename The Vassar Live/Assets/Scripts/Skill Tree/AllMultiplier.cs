using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMultiplier : SkillEffect
{
    public Attributes multiplier;
    UIHandler uh;

    public AllMultiplier(Attributes multiplier)
    {
        this.multiplier = multiplier;
    }

    public void skillActive()
    {
        foreach (KeyValuePair<string, Attributes> att in uh.MultiplierDict)
        {
            uh.MultiplierDict[att.Key] = att.Value.multiplyAttributes(multiplier);
        }
            }
}
