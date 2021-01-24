using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AdFinishEventArgs : EventArgs
{
   public string PlacementID
    {
        private set; get;
    }

    public UnityEngine.Advertisements.ShowResult AdShowResult
    {
        private set; get;
    }

    public AdFinishEventArgs(string id, UnityEngine.Advertisements.ShowResult result)
    {
        PlacementID = id;
        AdShowResult = result;
    }
}
