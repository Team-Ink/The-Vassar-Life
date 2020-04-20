using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboItem : Card
{
    public int index;
    public string comboType;
    public Attributes combo;

    public ComboItem()
    {

    }
	public ComboItem(string description, string effect, Attributes att, Attributes combo, string comboType, int index)
    {
        this.description = description;
        this.effect = effect;
        this.att = att;
        //this.note = note;
        this.combo = combo;
        this.comboType = comboType;
        this.index = index;

    }

}
