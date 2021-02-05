using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : View
{
	[Header("Title Screen Elements")]
	[SerializeField] private Image background;
	[SerializeField] private ExitGamePopup exitGamePopup;
	[SerializeField] private Image         playButtonImage;
	[SerializeField] private Image         exitButtonImage;

	private AudioClip acceptSfx;
	private AudioClip cancelSfx;

	protected override void OnInitialize()
	{
		background.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.TITLE_SCREEN,
		                                                                 AssetNames.Sprite.TITLE_BACKGROUND);

		playButtonImage.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.GENERAL,
		                                                                      AssetNames.Icon.PLAY);

		exitButtonImage.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.GENERAL,
		                                                                      AssetNames.Icon.CLOSE);

		acceptSfx = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.GENERAL,
		                                                AssetNames.SoundClip.ACCEPT);

		cancelSfx = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.GENERAL,
		                                                            AssetNames.SoundClip.CANCEL);
	}

	protected override void OnBackPressed()
	{
		OnExitGame();
	}

	public void OnStartGame()
	{
		Debug.Log("Start game!");
		AudioHandler.Instance.PlaySound(acceptSfx);
		SceneLoader.Instance.LoadScene(SceneNames.MainMenu);
	}

	public void OnExitGame()
	{
		Debug.Log("Attempting to quit game!");
		AudioHandler.Instance.PlaySound(cancelSfx);
		exitGamePopup.Show();
	}
}
