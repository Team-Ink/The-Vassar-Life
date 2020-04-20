using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveProf : SkillEffect
{
    UIHandler uh;
    CardPile cp;
    ProfCard professor;

    public void skillActive()
    {
        professor = cp.pickProf();
        //set flag, animate when exit button hit
        uh.processProf(professor);
        cp.profPile.Remove(professor);
    }
}
