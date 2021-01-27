using UnityEngine;
using Text = TMPro.TMP_Text;

public class MainMenuScreen : MonoBehaviour
{
	// TODO: Change background when orientation changes

	[SerializeField] private SettingsScreen settingsScreen;
	[SerializeField] private WorkshopScreen workshopScreen;
	[SerializeField] private ExchangeScreen exchangeScreen;
	[SerializeField] private ExitGamePopup  exitGamePopup;

	[SerializeField] private Text coinsValueText;
	[SerializeField] private Text kappaTokensValueText;

	[SerializeField] private AudioSource tapSFX;
	[SerializeField] private AudioSource successSFX;

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

		// AudioHandler.Instance.PlaySound(tapSFX);
		SceneLoader.Instance.LoadScene(SceneNames.Level);
	}

	public void OnGoToWorkshop()
	{
		// AudioHandler.Instance.PlaySound(tapSFX);
		workshopScreen.gameObject.SetActive(true);
	}

	public void OnExchangeCoinsForKappaTokens()
	{
		// Get data from game manager
		// * Player Currency Data
		// AudioHandler.Instance.PlaySound(tapSFX);
		exchangeScreen.WantedCurrency = CurrencyType.KAPPA_TOKEN;
		exchangeScreen.gameObject.SetActive(true);
	}

	public void OnExchangeKappaTokensForCoins()
	{
		// Get data from game manager
		// * Player Currency Data
		// AudioHandler.Instance.PlaySound(tapSFX);
		exchangeScreen.WantedCurrency = CurrencyType.COIN;
		exchangeScreen.gameObject.SetActive(true);
	}

	public void OnOpenSettings()
	{
		// AudioHandler.Instance.PlaySound(tapSFX);
		settingsScreen.gameObject.SetActive(true);
	}

	public void OnExitGame()
	{
		exitGamePopup.gameObject.SetActive(true);
	}
}
