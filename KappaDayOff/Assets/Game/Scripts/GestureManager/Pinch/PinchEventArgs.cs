using System;
using UnityEngine;

public class PinchEventArgs : EventArgs
{
	public PinchEventArgs(Touch f1, Touch f2, float dist)
	{
		finger1      = f1;
		finger2      = f2;
		DistanceDiff = dist;
	}

	public Touch finger1 { get; }
	public Touch finger2 { get; }

	public float DistanceDiff { get; }
}