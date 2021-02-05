using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : EnemyStats
{
    public AdsManager adsManager;

    public BossStats()
    {
        HP = 1000;
    }

    private void OnDestroy()
    {
        if (adsManager != null)
        {
            adsManager.ShowInterstitialAd();
            Debug.Log("End!");
            SceneLoader.Instance.LoadScene(SceneNames.MainMenu);
        }
    }
}
