using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TMP_Text;

public class ExchangeScreen : MonoBehaviour
{
	private const int          defaultAmountOfCurrency = 0;
	public        CurrencyType WantedCurrency          = CurrencyType.COIN;


	[SerializeField] private AudioSource tapSFX;
	[SerializeField] private AudioSource successSFX;

	private int quantityOfWantedCurrency;

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
		// AudioHandler.Instance.PlaySound(successSFX);

		CurrencyExchanger.CommenceExchange(WantedCurrency,
		                                   quantityOfWantedCurrency);
		quantityOfWantedCurrency = 0;

		ResetScreen();
	}

	public void OnAddWantedCurrency()
	{
		// AudioHandler.Instance.PlaySound(tapSFX);
		quantityOfWantedCurrency++;

		bool isExchangeValid = CurrencyExchanger.CheckForAffordability(WantedCurrency, quantityOfWantedCurrency);
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
		// AudioHandler.Instance.PlaySound(tapSFX);
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
		// AudioHandler.Instance.PlaySound(tapSFX);
		ResetScreen();
		gameObject.SetActive(false);
	}

	#region Currency Icons
	[Header("Currency Icons"), SerializeField]

     private Sprite coinsIcon;

	[SerializeField] private Sprite kappaTokensIcon;
	#endregion

	[Header("Wanted Currency"), SerializeField]

	#region Wanted Currency

     private Image wantedCurrencyIcon;

	[SerializeField] private Text wantedCurrencyText;
	#endregion

	#region Needed Currency Controls
	[Header("Needed Currency"), SerializeField]

     private Image neededCurrencyIcon;

	[SerializeField] private Text neededCurrencyText;
	#endregion
}
