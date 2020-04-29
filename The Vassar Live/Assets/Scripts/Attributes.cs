using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes
{
	public double AC =0;
	public double AR =0;
	public double S = 0;
	public double P = 0;
	public double H = 0;
	public Dictionary<string, double> attDict = new Dictionary<string, double>();


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
		attDict.Add("Academic", AC);
		attDict.Add("Art", AR);
		attDict.Add("Social", S);
		attDict.Add("Physique", P);
		attDict.Add("Happiness", H);
	}

	public Attributes addAttributes(Attributes att)
	{
		Attributes result = new Attributes(0,0,0,0,0);
		result.AC = AC+att.AC;
		result.AR = AR+att.AR;
		result.S = S+att.S;
		result.P = P+att.P;
		result.H += H+att.H;
		return result;
    }

    public Attributes multiplyAttributes (Attributes att)
    {
		Attributes result = new Attributes(0, 0, 0, 0, 0);
		result.AC = AC * att.AC;
		result.AR = AR * att.AR;
		result.S = S * att.S;
		result.P = P * att.P;
		result.H += H * att.H;
		return result;
	}

	public Attributes multiply(double n)
	{
		Attributes result = new Attributes(0, 0, 0, 0, 0);
		result.AC = AC *n;
		result.AR = AR * n;
		result.S = S * n;
		result.P = P * n;
		result.H += H * n;
		return result;
	}

	public bool equals(Attributes att)
    {
		if (AC == att.AC && AR == att.AR && S == att.S && P == att.P && H == att.H)
			return true;
		else return false;
    }
}
