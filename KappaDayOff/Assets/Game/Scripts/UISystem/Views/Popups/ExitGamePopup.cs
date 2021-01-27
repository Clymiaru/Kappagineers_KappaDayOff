using UnityEngine;
using UnityEngine.UI;

public class ExitGamePopup : OneChoicePopup
{
	private AudioClip tapSFX;
	private AudioClip cancelSFX;

	protected override void OnInitialize()
	{
		tapSFX = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.TITLE_SCREEN,
		                                                         AssetNames.SoundClip.ACCEPT);

		cancelSFX = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.TITLE_SCREEN,
		                                                            AssetNames.SoundClip.CANCEL);
	}

	public override void OnProceed()
	{
		// GameManager.Instance.SavePlayerData();
		AudioHandler.Instance.PlaySound(tapSFX);
		Debug.Log("Exit Game Proceed");
		OnExitEnd = Application.Quit;
		Hide();
	}

	public override void OnCancel()
	{
		AudioHandler.Instance.PlaySound(cancelSFX);
		Debug.Log("Exit Game Cancelled");
		Hide();
	}
}
