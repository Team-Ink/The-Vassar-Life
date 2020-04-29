using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
	public string name;
    public string description;
	public string effect;
	public string building;
	public string note = "" ;
	public Attributes att = new Attributes();
	public bool isRemovable;

	public Card()
	{
	}

	public Card(string description, string effect, Attributes att, string note, bool isRemovable, string building)
	{
		this.description = description;
		this.effect = effect;
		this.att = att;
		this.note = note;
		this.isRemovable = isRemovable;
        this.building = building;
	}

	public void updateState(Attributes playeratt)
    {
		playeratt.addAttributes(att);
	}
}
