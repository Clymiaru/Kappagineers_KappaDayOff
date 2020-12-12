using System.Collections;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    private void OnEnable()
    {
        GestureManager.Instance.OnTap  += OnStartGame;
        GestureManager.Instance.OnBack += OnExitGame;
    }
    
    private void OnDisable()
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
        Debug.Log("Exit Game");
    }
}
