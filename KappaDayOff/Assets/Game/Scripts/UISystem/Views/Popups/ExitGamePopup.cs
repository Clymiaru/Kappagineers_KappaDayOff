using UnityEngine;
using UnityEngine.UI;

public class ExitGamePopup : OneChoicePopup
{
	[Header("Exit Popup Elements")]
	[SerializeField] private Image proceedButtonImage;

	[SerializeField] private Image closeButtonImage;

	[SerializeField] private Image promptBackground;

	private AudioClip acceptSfx;
	private AudioClip cancelSfx;

	protected override void OnInitialize()
	{
		proceedButtonImage.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.GENERAL,
		                                                                         AssetNames.Sprite.BUTTON_01_BACKGROUND);

		closeButtonImage.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.GENERAL,
		                                                                       AssetNames.Icon.CLOSE);

		promptBackground.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.GENERAL,
		                                                                       AssetNames.Sprite.PROMPT_BACKGROUND);

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
