using System.Collections;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private ExitGamePopup exitGamePopup = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnExitGame();
        }
    }

    public void OnStartGame()
    {
        SceneLoader.Instance.LoadScene(SceneNames.MainMenu);
    }

    public void OnExitGame()
    {
        exitGamePopup.gameObject.SetActive(true);
    }
}
