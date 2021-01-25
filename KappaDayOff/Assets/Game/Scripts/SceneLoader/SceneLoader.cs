using UnityEngine.SceneManagement;

// TODO: Identify if we need to make a loading screen and asynchronous loading
public class SceneLoader
{
	public static SceneLoader Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new SceneLoader();
			}
			return instance;
		}
	}
	private static SceneLoader instance;

	private SceneLoader()
	{
	}

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
