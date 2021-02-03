using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TMP_Text;

public class MainMenuScreen : View
{
	// TODO: Change background when orientation changes

	[SerializeField] private SettingsScreen settingsScreen;
	[SerializeField] private WorkshopScreen workshopScreen;
	[SerializeField] private ExchangeScreen exchangeScreen;
	[SerializeField] private ExitGamePopup  exitGamePopup;

	[Header("Main Menu Screen Elements")]
	[SerializeField] private Image background;

	[SerializeField] private Image coinsExchangeIcon;
	[SerializeField] private Text coinsValueText;

	[SerializeField] private Image kappaTokensExchangeIcon;
	[SerializeField] private Text  kappaTokensValueText;

	private AudioClip acceptSFX;
	private AudioClip cancelSFX;

	private CurrencyData playerCurrency;

	private void Start()
	{
		// playerCurrency = GameManager.Instance.PlayerCurrency;

		// coinsValueText.text       = playerCurrency.Coins.ToString();
		// kappaTokensValueText.text = playerCurrency.KappaTokens.ToString();
	}


	private void Update()
	{
		// coinsValueText.text       = playerCurrency.Coins.ToString();
		// kappaTokensValueText.text = playerCurrency.KappaTokens.ToString();
	}

	protected override void OnInitialize()
	{
		background.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.MAIN_MENU_SCREEN,
		                                                                 AssetNames.Sprite.WORKSHOP_BACKGROUND);

		coinsExchangeIcon.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.MAIN_MENU_SCREEN,
		                                                                        AssetNames.Icon.PLUS);

		kappaTokensExchangeIcon.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.MAIN_MENU_SCREEN,
		                                                                              AssetNames.Icon.PLUS);

		acceptSFX = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.GENERAL,
		                                                            AssetNames.SoundClip.ACCEPT);

		cancelSFX = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.TITLE_SCREEN,
		                                                            AssetNames.SoundClip.CANCEL);
	}

	protected override void OnBackPressed()
	{
		OnExitGame();
	}

	// public void OnGoToDeparture()
	// {
	// 	// HACK: Skip to level for now
	// 	// TODO: Go to level selection screen if we have enough time.
	//
	// 	// AudioHandler.Instance.PlaySound(tapSFX);
	// 	SceneLoader.Instance.LoadScene(SceneNames.Level);
	// }
	//
	// public void OnGoToWorkshop()
	// {
	// 	// AudioHandler.Instance.PlaySound(tapSFX);
	// 	workshopScreen.gameObject.SetActive(true);
	// }
	//
	// public void OnExchangeCoinsForKappaTokens()
	// {
	// 	// Get data from game manager
	// 	// * Player Currency Data
	// 	// AudioHandler.Instance.PlaySound(tapSFX);
	// 	exchangeScreen.WantedCurrency = CurrencyType.KAPPA_TOKEN;
	// 	exchangeScreen.gameObject.SetActive(true);
	// }
	//
	// public void OnExchangeKappaTokensForCoins()
	// {
	// 	// Get data from game manager
	// 	// * Player Currency Data
	// 	// AudioHandler.Instance.PlaySound(tapSFX);
	// 	exchangeScreen.WantedCurrency = CurrencyType.COIN;
	// 	exchangeScreen.gameObject.SetActive(true);
	// }
	//
	// public void OnOpenSettings()
	// {
	// 	// AudioHandler.Instance.PlaySound(tapSFX);
	// 	// settingsScreen.gameObject.SetActive(true);
	// }

	private void OnExitGame()
	{
		exitGamePopup.Show();
	}
}
