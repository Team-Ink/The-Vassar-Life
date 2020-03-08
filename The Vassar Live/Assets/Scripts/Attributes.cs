using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes
{
	public double AC;
	public double AR;
	public double S;
	public double P;
	public double H;
	public Attributes()
	{

	}

	public Attributes(double AC, double AR, double S, double P, double H)
	{
		this.AC = AC;
		this.AR = AR;
		this.S = S;
		this.P = P;
		this.H = H;
	}

	public void addAttributes(Attributes att)
	{
		this.AC += att.AC;
		this.AR += att.AR;
		this.S += att.S;
		this.P += att.P;
		this.H += att.H;
    }
}
