using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PanEventArgs : EventArgs
{
    public Touch finger1 { get; private set; }
    public Touch finger2 { get; private set; }

    public PanEventArgs(Touch f1, Touch f2)
    {
        finger1 = f1;
        finger2 = f2;
    }
}
