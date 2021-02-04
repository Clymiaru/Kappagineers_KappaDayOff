using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdRewards : MonoBehaviour
{
    public int rewardForWatchingAds = 1;
    public AdsManager adManager;

    // Start is called before the first frame update
    void Start()
    {
        adManager.OnAdDone += AdManager_OnAdDone;
    }

    private void AdManager_OnAdDone(object sender, AdFinishEventArgs e)
    {
        if (e.PlacementID == AdsManager.SampleRewardedAd)
        {
            switch (e.AdShowResult)
            {
                case UnityEngine.Advertisements.ShowResult.Failed:
                    break;
                case UnityEngine.Advertisements.ShowResult.Skipped:
                    break;
                case UnityEngine.Advertisements.ShowResult.Finished:
                    // GameManager.Instance.PlayerCurrency.KappaTokens += rewardForWatchingAds;
                    break;
            }
        }
    }
}
