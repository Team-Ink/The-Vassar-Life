﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSkill: SkillEffect
{
    public Attributes add;
    public string addType;
    UIHandler uh;

    public AddSkill(Attributes add, string addType)
    {
        this.add = add;
        this.addType = addType;
    }

    public void skillActive()
    {
        uh.BonusDict[addType] = uh.BonusDict[addType].addAttributes(add);
    }
}
