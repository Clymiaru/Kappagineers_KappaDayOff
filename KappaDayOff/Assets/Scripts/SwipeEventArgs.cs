using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SwipeDirections
{
    UP, DOWN, LEFT, RIGHT
}

public class SwipeEventArgs : EventArgs
{
    private Vector2 swipePos;
    private Vector2 swipeVector;
    private SwipeDirections swipeDirection;

    public SwipeEventArgs(Vector2 pos, Vector2 v, SwipeDirections dir)
    {
        swipePos = pos;
        swipeVector = v;
        swipeDirection = dir;
    }

    public Vector2 SwipePos
    {
        get
        {
            return swipePos;
        }
    }

    public Vector2 SwipeVector
    {
        get
        {
            return swipeVector;
        }
    }

    public SwipeDirections SwipeDirection
    {
        get
        {
            return swipeDirection;
        }
    }
}
