using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : View
{
	[Header("Title Screen Elements")]
	[SerializeField] private Image background;

	[SerializeField] private ExitGamePopup exitGamePopup;

	protected override void OnBackPressed()
	{
		OnExitGame();
	}

	private void Initialize()
	{
	}

	public void OnStartGame()
	{
		Debug.Log("Start game!");
		SceneLoader.Instance.LoadScene(SceneNames.MainMenu);
	}

	public void OnExitGame()
	{
		exitGamePopup.gameObject.SetActive(true);
	}
}
