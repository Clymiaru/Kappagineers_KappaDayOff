using System;
using UnityEngine;

public class PanEventArgs : EventArgs
{
	public PanEventArgs(Touch f1, Touch f2)
	{
		finger1 = f1;
		finger2 = f2;
	}

	public Touch finger1 { get; }
	public Touch finger2 { get; }
}