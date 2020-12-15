using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PinchEventArgs : EventArgs
{
    public Touch finger1 { get; private set; }
    public Touch finger2 { get; private set; }

    public float DistanceDiff { get; private set; }
    
    public PinchEventArgs(Touch f1, Touch f2, float dist)
    {
        finger1 = f1;
        finger2 = f2;
        DistanceDiff = dist;
    }
}
