using UnityEngine;

public class ExitGamePopup : MonoBehaviour
{
    [SerializeField] private TitleScreen titleScreen;
    
    public void OnExitGameProceed()
    {
        // Fade to black
        // Save relevant data
        // Free memory
        
        // Another way is to flag for quiting the game and let other classes do the necessary work
        Debug.Log("Exit Game Proceed");
        Application.Quit();
    }

    public void OnCancelExitGame()
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
