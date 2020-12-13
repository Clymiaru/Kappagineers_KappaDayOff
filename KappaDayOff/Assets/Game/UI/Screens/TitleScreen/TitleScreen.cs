using System.Collections;
using UnityEngine;

public class TitleScreen : MonoBehaviour, IView
{
    [SerializeField] private ExitGamePopup exitGamePopup;

    public void Show()
    {
        // TODO: Fade in screen transition
        
        // Once animation ends and everything is setup
        RegisterInputEvents();
        
        // Callback
    }

    public void Hide()
    {
        DegisterInputEvents();

        // TODO: Fade to black screen transition
        // Once animation ends and everything is setup
        
        // Callback
    }
    
    private void OnEnable()
    {
        RegisterInputEvents();
    }

    private void OnDisable()
    {
        DegisterInputEvents();
    }

    private void RegisterInputEvents()
    {
        GestureManager.Instance.OnTap  += OnStartGame;
        GestureManager.Instance.OnBack += OnExitGame;
    }

    private void DegisterInputEvents()
    {
        GestureManager.Instance.OnTap  -= OnStartGame;
        GestureManager.Instance.OnBack -= OnExitGame;
    }

    private void OnStartGame(object obj, TapEventArgs args)
    {
        SceneLoader.LoadScene(SceneNames.MainMenu);
        Debug.Log("Start Game");
    }

    private void OnExitGame()
    {
        DegisterInputEvents();
        exitGamePopup.Show();
        
        Debug.Log("Exit Game");
    }
}
