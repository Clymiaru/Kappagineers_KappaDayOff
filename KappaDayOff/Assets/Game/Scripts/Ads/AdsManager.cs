using System.Collections;
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

    public static AdsManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(GameID, true);

        DeviceOrientationHandler.Instance.OnOrientationUpdate +=
                (orientation) =>
                 {
                     HideBannerAd();
                     ShowBannerAd(orientation);
                 };
    }

    public void ShowInterstitialAd()
    {
        if (Advertisement.IsReady(SampleInterstitialAd))
            Advertisement.Show(SampleInterstitialAd);
    }

    public void ShowBannerAd(DeviceOrientation orientation)
    {
        StartCoroutine(ShowBannerAd_Routine(orientation));
    }

    public void HideBannerAd()
    {
        if (Advertisement.Banner.isLoaded)
            Advertisement.Banner.Hide();
    }

    IEnumerator ShowBannerAd_Routine(DeviceOrientation orientation)
    {
        while (!Advertisement.isInitialized)
            yield return new WaitForSeconds(0.5f);

        if (orientation == DeviceOrientation.Portrait ||
            orientation == DeviceOrientation.PortraitUpsideDown)
        {
            Advertisement.Banner.SetPosition(BannerPosition.CENTER);
        }
        else if (orientation == DeviceOrientation.LandscapeRight ||
                 orientation == DeviceOrientation.LandscapeLeft)
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        }

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
