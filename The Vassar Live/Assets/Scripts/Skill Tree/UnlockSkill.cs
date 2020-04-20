using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSkill : SkillEffect
{
    bool unlock;
    string building;
    UIHandler uh;

    UnlockSkill(string building, bool unlock)
    {
        this.building = building;
        this.unlock = unlock;
    }

    public void skillActive()
    {
        uh.unlockDict[building] = unlock;
    }
}
