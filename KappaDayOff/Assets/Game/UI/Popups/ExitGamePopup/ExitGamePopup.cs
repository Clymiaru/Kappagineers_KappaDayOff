using UnityEngine;

public class ExitGamePopup : MonoBehaviour, IView
{
    private TitleScreen titleScreen;
    
    private void OnEnable()
    {
        GestureManager.Instance.OnTap += OnCancelExitGame;
        
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnTap -= OnCancelExitGame;
    }

    public void OnExitGameProceed()
    {
        // Fade to black
        // Save relevant data
        // Free memory
        
        // Another way is to flag for quiting the game and let other classes do the necessary work
        Application.Quit();
    }

    private void OnCancelExitGame(object obj, TapEventArgs args)
    {
        Hide();
        titleScreen.Show();
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
