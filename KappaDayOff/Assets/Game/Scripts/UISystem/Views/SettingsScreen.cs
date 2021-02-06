using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using Text = TMPro.TMP_Text;

public class SettingsScreen : View
{
	[SerializeField] private View previousView;

	[SerializeField] private GameObject soundOptionsPanel;
	[SerializeField] private GameObject debugOptionsPanel;

	private                  AudioClip  acceptSFX;
	private                  AudioClip  cancelSFX;

	protected override void OnInitialize()
	{
		acceptSFX = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.GENERAL,
		                                                            AssetNames.SoundClip.ACCEPT);

		cancelSFX = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.GENERAL,
		                                                            AssetNames.SoundClip.CANCEL);

		debugOptionsPanel.SetActive(false);
		soundOptionsPanel.SetActive(true);
	}

	protected override void OnBackPressed()
	{
		OnExitScreen();
	}

	public void OnExitScreen()
	{
		AudioHandler.Instance.PlaySound(cancelSFX);
		previousView.Show();
		Hide();
	}

	public void OnSoundOptionsSelect()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);
		debugOptionsPanel.SetActive(false);
		soundOptionsPanel.SetActive(true);
	}

	public void OnDebugOptionsSelect()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);
		debugOptionsPanel.SetActive(true);
		soundOptionsPanel.SetActive(false);
	}

	public void OnNotifyLevelUnlock()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);
	}

	public void OnPlayVideoAds()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);
		AdsManager.Instance.ShowInterstitialAd();

	}

	public void OnPlayRewardedAds()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);

	}

	public void OnUnlimitedMoney()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);
		GameManager.Instance.UnlimitedMoney();
	}

	public void OnUnlockAllLevels()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);
		GameManager.Instance.UnlockAllLevels();
	}

	public void OnResetPlayerProgress()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);
		GameManager.Instance.ResetPlayerProgress();
	}
}
