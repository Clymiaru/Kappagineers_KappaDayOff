using UnityEngine;

public class ExitGamePopup : MonoBehaviour
{
    [SerializeField] private GameObject previousScreen = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnCancelExitGame();
        }
    }

    public void OnExitGameProceed()
    {
        GameManager.Instance.SavePlayerData();
        
        Debug.Log("Exit Game Proceed");
        Application.Quit();
    }

    public void OnCancelExitGame()
    {
        gameObject.SetActive(false);
        previousScreen.SetActive(true);
    }
}
