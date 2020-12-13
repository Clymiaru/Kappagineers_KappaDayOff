using System.Collections;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private ExitGamePopup exitGamePopup;
    
    public void Show()
    {
        // TODO: Fade in screen transition
        // Once animation ends and everything is setup

        // Callback
    }

    public void Hide()
    {
        // TODO: Fade to black screen transition
        // Once animation ends and everything is setup
        
        // Callback
    }

    // By Tapping anywhere on the screen
    public void OnStartGame()
    {
        SceneLoader.LoadSceneDebug(SceneNames.MainMenu);
        Debug.Log("Start Game");
    }

    // By pressing the back button
    public void OnExitGame()
    {
        exitGamePopup.Show();
        Debug.Log("Exit Game");
    }
}
