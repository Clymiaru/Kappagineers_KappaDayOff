using UnityEngine;

public class MainMenuScreen : MonoBehaviour
{
    // TODO: Change background when orientation changes

    [SerializeField] private SettingsScreen       settingsScreen = null;
    [SerializeField] private LevelSelectionScreen levelSelectionScreen = null;
    [SerializeField] private WorkshopScreen       workshopScreen = null;
    
    public void OnGoToDeparture()
    {
        levelSelectionScreen.gameObject.SetActive(true);
    }

    public void OnGoToWorkshop()
    {
        workshopScreen.gameObject.SetActive(true);
    }

    public void OnExchangeCoinToKappaTokens()
    {
        
    }

    public void OnExchangeKappaTokensToCoins()
    {
        
    }

    public void OnOpenSettings()
    {
        settingsScreen.gameObject.SetActive(true);
    }
    
    
}
