using System;

[Serializable]
public class CurrencyData
{
	public int Coins;
	public int KappaTokens;

	public CurrencyData(int coins = 1000, int kappaTokens = 3)
	{
		Coins       = coins;
		KappaTokens = kappaTokens;
	}
}
