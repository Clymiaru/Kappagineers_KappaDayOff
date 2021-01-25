using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public event EventHandler<AdFinishEventArgs> OnAdDone;

    public string GameID
    {
        get
        {
#if UNITY_ANDROID
            return "3983609";
#elif UNITY_IOS
            return "3983608";
#else
            return null;
#endif
        }
    }

    public const string SampleInterstitialAd = "video";
    public const string SampleRewardedAd = "rewardedVideo";
    public const string SampleBannerAd = "sample";

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(GameID, true);
    }

    public void ShowInterstitialAd()
    {
        if (Advertisement.IsReady(SampleInterstitialAd))
            Advertisement.Show(SampleInterstitialAd);
    }

    public void ShowBannerAd()
    {
        StartCoroutine(ShowBannerAd_Routine());
    }

    public void HideBannerAd()
    {
        if (Advertisement.Banner.isLoaded)
            Advertisement.Banner.Hide();
    }

    IEnumerator ShowBannerAd_Routine()
    {
        while (!Advertisement.isInitialized)
            yield return new WaitForSeconds(0.5f);

        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(SampleBannerAd);
    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
       if (OnAdDone != null)
        {
            AdFinishEventArgs args = new AdFinishEventArgs(placementId, showResult);
            OnAdDone(this, args);
        }
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady(SampleRewardedAd))
            Advertisement.Show(SampleRewardedAd);
    }
}
