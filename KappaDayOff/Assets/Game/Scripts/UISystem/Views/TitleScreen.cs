using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : View
{
	[Header("Title Screen Elements")]
	[SerializeField] private Image background;
	[SerializeField] private ExitGamePopup exitGamePopup;

	protected override void OnInitialize()
	{
		background.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.TITLE_SCREEN,
		                                                                 AssetNames.Sprite.BACKGROUND);
	}

	protected override void OnBackPressed()
	{
		OnExitGame();
	}

	public void OnStartGame()
	{
		Debug.Log("Start game!");
		SceneLoader.Instance.LoadScene(SceneNames.MainMenu);
	}

	public void OnExitGame()
	{
		exitGamePopup.Show();
		Debug.Log("Quit game!");
	}
}
