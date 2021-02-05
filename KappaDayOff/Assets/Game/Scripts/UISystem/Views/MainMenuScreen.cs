using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TMP_Text;

public class MainMenuScreen : View
{
	// TODO: Change background when orientation changes

    [Header("Screens")]
	[SerializeField] private SettingsScreen settingsScreen;
	[SerializeField] private WorkshopScreen workshopScreen;
	[SerializeField] private ExchangeScreen exchangeScreen;
	[SerializeField] private ExitGamePopup  exitGamePopup;

	[Header("Main Menu Screen Elements")]
	[SerializeField] private Image background;

	[SerializeField] private Image watchAdButtonIcon;
	[SerializeField] private Image settingsButtonIcon;
	[SerializeField] private Image departButtonIcon;
	[SerializeField] private Image upgradesButtonIcon;

	[SerializeField] private Image coinsExchangeIcon;
	[SerializeField] private Image kappaTokensExchangeIcon;

	[SerializeField] private Image coinIcon;
	[SerializeField] private Image kappaTokenIcon;

	[SerializeField] private Image coinButtonBackground;
	[SerializeField] private Image kappaTokenButtonBackground;


	private AudioClip acceptSFX;
	private AudioClip cancelSFX;

	private AudioClip bgm;

	protected override void OnInitialize()
	{
		background.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.MAIN_MENU_SCREEN,
		                                                                 AssetNames.Sprite.WORKSHOP_BACKGROUND);

		coinsExchangeIcon.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.MAIN_MENU_SCREEN,
		                                                                        AssetNames.Icon.PLUS);

		kappaTokensExchangeIcon.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.MAIN_MENU_SCREEN,
		                                                                              AssetNames.Icon.PLUS);

		watchAdButtonIcon.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.MAIN_MENU_SCREEN,
		                                                                        AssetNames.Icon.WATCH_AD);

		settingsButtonIcon.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.MAIN_MENU_SCREEN,
		                                                                         AssetNames.Icon.SETTINGS);

		departButtonIcon.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.MAIN_MENU_SCREEN,
		                                                                       AssetNames.Icon.DEPART);

		upgradesButtonIcon.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.MAIN_MENU_SCREEN,
		                                                                         AssetNames.Icon.UPGRADES);

		coinIcon.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.MAIN_MENU_SCREEN,
		                                                               AssetNames.Icon.COIN);

		kappaTokenIcon.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.MAIN_MENU_SCREEN,
		                                                               AssetNames.Icon.KAPPA_TOKEN);

		coinButtonBackground.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.GENERAL,
		                                                                           AssetNames.Sprite.BUTTON_01_BACKGROUND);

		kappaTokenButtonBackground.sprite = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.GENERAL,
		                                                                                 AssetNames.Sprite.BUTTON_01_BACKGROUND);

		acceptSFX = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.GENERAL,
	                                                            AssetNames.SoundClip.ACCEPT);

		cancelSFX = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.GENERAL,
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

	public void OnDepart()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);
		// settingsScreen.Show();
	}
	public void OnOpenSettings()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);
		Hide();
		settingsScreen.Show();
	}

	public void OnWatchAds()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);
		// settingsScreen.Show();
	}
	public void OnOpenUpgrades()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);
		Hide();
		// settingsScreen.Show();
	}

	private void OnExitGame()
	{
		exitGamePopup.Show();
	}
}
