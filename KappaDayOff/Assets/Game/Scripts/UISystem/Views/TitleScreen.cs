using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : View
{
	[Header("Title Screen Elements")]
	[SerializeField] private Image background;
	[SerializeField] private ExitGamePopup exitGamePopup;

	private AudioClip tapSFX;
	private AudioClip cancelSFX;

	protected override void OnInitialize()
	{
		background.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.TITLE_SCREEN,
		                                                                 AssetNames.Sprite.BACKGROUND);

		tapSFX = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.TITLE_SCREEN,
		                                                AssetNames.SoundClip.ACCEPT);

		cancelSFX = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.TITLE_SCREEN,
		                                                            AssetNames.SoundClip.CANCEL);
	}

	protected override void OnBackPressed()
	{
		OnExitGame();
	}

	public void OnStartGame()
	{
		Debug.Log("Start game!");
		AudioHandler.Instance.PlaySound(tapSFX);
		SceneLoader.Instance.LoadScene(SceneNames.MainMenu);
	}

	public void OnExitGame()
	{
		Debug.Log("Attempting to quit game!");
		AudioHandler.Instance.PlaySound(cancelSFX);
		exitGamePopup.Show();
	}
}
