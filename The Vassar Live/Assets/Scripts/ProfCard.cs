using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfCard : Card
{
    public string profBonus;
    public Attributes bonus = new Attributes();
    public Attributes combo = new Attributes();
    public int index;
    public string bonusType;

    public ProfCard(string name, string effect, string profBonus, Attributes bonus, Attributes combo,int index, string bonusType)
    {
        this.name = name;
        this.effect = effect;
        this.bonus = bonus;
        this.profBonus = profBonus;
        this.combo = combo;
        this.index = index;
        this.bonusType = bonusType;

    }

    public void updateState(Attributes playeratt, Attributes bonus)
    {

    }
}
