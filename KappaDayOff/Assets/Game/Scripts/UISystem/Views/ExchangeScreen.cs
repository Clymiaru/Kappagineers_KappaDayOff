using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TMP_Text;

public class ExchangeScreen : View
{
	[Header("Wanted Currency")]
	[SerializeField] private Image wantedCurrencyIcon;
	[SerializeField] private Text wantedCurrencyText;

	[Header("Needed Currency")]
	[SerializeField] private Image neededCurrencyIcon;
	[SerializeField] private Text neededCurrencyText;

	private const int          defaultAmountOfCurrency = 0;
	public        CurrencyType WantedCurrency          = CurrencyType.COIN;




	private AudioClip acceptSFX;
	private AudioClip cancelSFX;

	private int quantityOfWantedCurrency;

	private Sprite coinsIcon;
	private Sprite kappaTokensIcon;
	private Sprite plusIcon;
	private Sprite minusIcon;

	protected override void OnInitialize()
	{
		coinsIcon = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.MAIN_MENU,
		                                                            AssetNames.Icon.COIN);

		kappaTokensIcon = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.MAIN_MENU,
		                                                               AssetNames.Icon.KAPPA_TOKEN);

		plusIcon = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.GENERAL,
		                                                        AssetNames.Icon.PLUS);

		minusIcon = AssetBundleManager.Instance.GetAsset<Sprite>(AssetBundleNames.GENERAL,
		                                                         AssetNames.Icon.MINUS);

		acceptSFX = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.GENERAL,
		                                                            AssetNames.SoundClip.ACCEPT);

		cancelSFX = AssetBundleManager.Instance.GetAsset<AudioClip>(AssetBundleNames.GENERAL,
		                                                            AssetNames.SoundClip.CANCEL);

	}

	protected override void OnBackPressed()
	{
		OnExitScreen();
	}

	private void OnEnable()
	{
		ResetScreen();
		UpdateCurrencySprites();
	}

	private void UpdateCurrencySprites()
	{
		switch (WantedCurrency)
		{
			case CurrencyType.COIN:
			{
				wantedCurrencyIcon.sprite = coinsIcon;
				neededCurrencyIcon.sprite = kappaTokensIcon;
				break;
			}
			case CurrencyType.KAPPA_TOKEN:
			{
				wantedCurrencyIcon.sprite = kappaTokensIcon;
				neededCurrencyIcon.sprite = coinsIcon;
				break;
			}
			default:
			{
				Debug.LogWarning("Attempting to update sprite an undefined currency!");
				break;
			}
		}
	}

	public void OnExchange()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);

		Debug.Log("Exchange");

		CurrencyExchanger.CommenceExchange(WantedCurrency,
		                                   quantityOfWantedCurrency);
		quantityOfWantedCurrency = 0;

		ResetScreen();
	}

	public void OnAddWantedCurrency()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);
		quantityOfWantedCurrency++;

		bool isExchangeValid = CurrencyExchanger.CheckForAffordability(WantedCurrency, quantityOfWantedCurrency,
		                                                               GameManager.Instance.PlayerData.PlayerCurrency);
		if (!isExchangeValid)
		{
			quantityOfWantedCurrency--;
		}

		int rawAmountOfCurrency = CurrencyExchanger.GetAmountWithConversion(WantedCurrency, quantityOfWantedCurrency);

		wantedCurrencyText.text = rawAmountOfCurrency.ToString();
		UpdateExchangedCurrency();
	}

	public void OnSubtractWantedCurrency()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);
		quantityOfWantedCurrency--;
		quantityOfWantedCurrency = Mathf.Max(quantityOfWantedCurrency, 0);

		int rawAmountOfCurrency = CurrencyExchanger.GetAmountWithConversion(WantedCurrency, quantityOfWantedCurrency);

		wantedCurrencyText.text = rawAmountOfCurrency.ToString();

		UpdateExchangedCurrency();
	}

	private void UpdateExchangedCurrency()
	{
		int rawAmountOfNeededCurrency = 0;
		rawAmountOfNeededCurrency = CurrencyExchanger.GetRequiredCurrency(WantedCurrency, quantityOfWantedCurrency);
		neededCurrencyText.text   = rawAmountOfNeededCurrency.ToString();
	}

	private void ResetScreen()
	{
		quantityOfWantedCurrency = defaultAmountOfCurrency;
		wantedCurrencyText.text  = defaultAmountOfCurrency.ToString();
		neededCurrencyText.text  = defaultAmountOfCurrency.ToString();
	}

	public void OnExitScreen()
	{
		AudioHandler.Instance.PlaySound(acceptSFX);
		ResetScreen();
		Hide();
	}
}
