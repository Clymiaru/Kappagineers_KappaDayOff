using UnityEngine;

public class TitleScreen : View
{
	[SerializeField] private ExitGamePopup exitGamePopup;

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
		exitGamePopup.gameObject.SetActive(true);
	}
}
