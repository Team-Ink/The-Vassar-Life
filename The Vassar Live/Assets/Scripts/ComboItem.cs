using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboItem : Card
{
    int index;
    public ComboItem()
    {

    }
	public ComboItem(string description, string effect, Attributes att, string note, int index)
	{
		this.description = description;
		this.effect = effect;
		this.att = att;
		this.note = note;
		this.index = index;
    }
}
