using System;
using UnityEditor.UI;
using UnityEngine;

using Text = TMPro.TMP_Text;

public class MainMenuScreen : MonoBehaviour
{
    // TODO: Change background when orientation changes

    [SerializeField] private SettingsScreen settingsScreen = null;
    [SerializeField] private WorkshopScreen workshopScreen = null;
    [SerializeField] private ExchangeScreen exchangeScreen = null;
    [SerializeField] private ExitGamePopup  exitGamePopup  = null;

    [SerializeField] private Text coinsValueText       = null;
    [SerializeField] private Text kappaTokensValueText = null;

    [SerializeField] private AudioSource tapSFX = null;
    [SerializeField] private AudioSource successSFX = null;
    
    private CurrencyData playerCurrency;
    private void Start()
    {
        playerCurrency = GameManager.Instance.PlayerCurrency;
        
        coinsValueText.text       = playerCurrency.Coins.ToString();
        kappaTokensValueText.text = playerCurrency.KappaTokens.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnExitGame();
        }
        
        coinsValueText.text       = playerCurrency.Coins.ToString();
        kappaTokensValueText.text = playerCurrency.KappaTokens.ToString();
    }

    public void OnGoToDeparture()
    {
        // HACK: Skip to level for now
        // TODO: Go to level selection screen if we have enough time.
        
        AudioHandler.Instance.PlaySFX(tapSFX);
        SceneLoader.Instance.LoadScene(SceneNames.Level);
    }

    public void OnGoToWorkshop()
    {
        AudioHandler.Instance.PlaySFX(tapSFX);
        workshopScreen.gameObject.SetActive(true);
    }

    public void OnExchangeCoinsForKappaTokens()
    {
        // Get data from game manager
        // * Player Currency Data
        AudioHandler.Instance.PlaySFX(tapSFX);
        exchangeScreen.WantedCurrency = CurrencyType.KAPPA_TOKEN;
        exchangeScreen.gameObject.SetActive(true);
    }

    public void OnExchangeKappaTokensForCoins()
    {
        // Get data from game manager
        // * Player Currency Data
        AudioHandler.Instance.PlaySFX(tapSFX);
        exchangeScreen.WantedCurrency = CurrencyType.COIN;
        exchangeScreen.gameObject.SetActive(true);
    }

    public void OnOpenSettings()
    {
        AudioHandler.Instance.PlaySFX(tapSFX);
        settingsScreen.gameObject.SetActive(true);
    }

    public void OnExitGame()
    {
        exitGamePopup.gameObject.SetActive(true);
    }
}
