using UnityEngine;
using UnityEngine.UI;

public class ExitGamePopup : OneChoicePopup
{
	private AudioClip acceptSfx;
	private AudioClip cancelSfx;

	protected override void OnInitialize()
	{
		acceptSfx = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.GENERAL,
		                                                         AssetNames.SoundClip.ACCEPT);

		cancelSfx = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.GENERAL,
		                                                            AssetNames.SoundClip.CANCEL);
	}

	public override void OnProceed()
	{
		// GameManager.Instance.SavePlayerData();
		AudioHandler.Instance.PlaySound(acceptSfx);
		Debug.Log("Exit Game Proceed");
		OnExitEnd = Application.Quit;
		Hide();
	}

	public override void OnCancel()
	{
		AudioHandler.Instance.PlaySound(cancelSfx);
		Debug.Log("Exit Game Cancelled");
		Hide();
	}
}
