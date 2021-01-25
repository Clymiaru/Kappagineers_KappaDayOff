using System;
using UnityEngine;

[Serializable]
public class SwipeProperty
{
	[Tooltip("Minimum Distance covered to be a swipe")]
	public float minSwipeDistance = 2f;

	[Tooltip("Maximum gesture time until its not a swipe anymore")]
	public float swipeTime = 0.7f;
}