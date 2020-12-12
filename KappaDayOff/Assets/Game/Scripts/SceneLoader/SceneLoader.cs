using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private static SceneLoader sharedInstance = null;
    public static SceneLoader Instance 
    {
        get 
        {
            if (sharedInstance == null) 
            {
                sharedInstance = new SceneLoader();
            }

            return sharedInstance;
        }
    }
    
    public static void LoadScene(string sceneName)
    {
        // Load the loading screen scene with a UI overlay
        // When the loading is complete, transition to the target scene
        SceneManager.LoadScene(sceneName);
    }
}
