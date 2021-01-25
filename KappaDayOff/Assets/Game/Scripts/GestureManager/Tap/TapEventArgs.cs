using System;
using UnityEngine;

public class TapEventArgs : EventArgs
{
	public TapEventArgs(Vector2 tapPosition, GameObject hitObject = null)
	{
		TapPosition = tapPosition;
		HitObject   = hitObject;
	}

	public Vector2    TapPosition { get; }
	public GameObject HitObject   { get; }
}