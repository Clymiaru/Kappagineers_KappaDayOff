using System;
using UnityEngine;

public enum SwipeDirections
{
	UP,
	DOWN,
	LEFT,
	RIGHT
}

public class SwipeEventArgs : EventArgs
{
	public SwipeEventArgs(Vector2 pos, Vector2 v, SwipeDirections dir)
	{
		SwipePos       = pos;
		SwipeVector    = v;
		SwipeDirection = dir;
	}

	public Vector2 SwipePos { get; }

	public Vector2 SwipeVector { get; }

	public SwipeDirections SwipeDirection { get; }
}