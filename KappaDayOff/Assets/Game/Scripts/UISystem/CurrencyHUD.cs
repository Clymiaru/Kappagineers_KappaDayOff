using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CurrencyHUD : MonoBehaviour
{
	[SerializeField] private TMPro.TMP_Text coinValueText;
	[SerializeField] private TMPro.TMP_Text kappaTokenValueText;

	private void OnEnable()
	{
		EventBroadcaster.Instance.AddObserver(EventNames.Currency.ON_SET_CURRENCY, UpdateCurrencyDisplay);
	}

	private void OnDisable()
	{
		EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.Currency.ON_SET_CURRENCY, UpdateCurrencyDisplay);
	}

	private void UpdateCurrencyDisplay(Parameters parameters)
	{
		int kappaTokens = parameters.GetIntExtra("KappaTokens", 0);
		int coins = parameters.GetIntExtra("Coins", 0);

		coinValueText.text       = coins.ToString("N0");
		kappaTokenValueText.text = kappaTokens.ToString("N0");
	}
}
