using System.Collections;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private ExitGamePopup exitGamePopup = null;

    [SerializeField] private AudioSource audioSource = null;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnExitGame();
        }
    }

    public void OnStartGame()
    {
        AudioHandler.Instance.PlaySFX(audioSource);
        SceneLoader.Instance.LoadScene(SceneNames.MainMenu);
    }

    public void OnExitGame()
    {
        exitGamePopup.gameObject.SetActive(true);
    }
}
