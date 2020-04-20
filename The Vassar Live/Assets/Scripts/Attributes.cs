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
		AC += att.AC;
		AR += att.AR;
		S += att.S;
		P += att.P;
		H += att.H;
    }

    public void multiplyAttributes (Attributes att)
    {
		AC *= att.AC;
		AR *= att.AR;
		S *= att.S;
		P *= att.P;
		H *= att.H;
	}

    public bool equals(Attributes att)
    {
		if (AC == att.AC && AR == att.AR && S == att.S && P == att.P && H == att.H)
			return true;
		else return false;
    }
}
