using UnityEngine;

public enum CurrencyType
{
    COIN,
    KAPPA_TOKEN
}

public static class CurrencyExchanger
{
    private const int CoinToKappaToken = 1200;
    private const int KappaTokenToCoin = 400;
    public static void CommenceExchange(CurrencyType wantedCurrency, 
                                        int          quantityOfWantedCurrency)
    {
        if (wantedCurrency == CurrencyType.COIN) // Kappa Token To Coin
        {
            int amountAddedToWantedCurrency = quantityOfWantedCurrency * KappaTokenToCoin;
            int amountAddedToNeededCurrency = quantityOfWantedCurrency;
            
            GameManager.Instance.UpdateCurrency(CurrencyType.COIN, amountAddedToWantedCurrency);
            GameManager.Instance.UpdateCurrency(CurrencyType.KAPPA_TOKEN, -amountAddedToNeededCurrency);
            
            // Debug.Log("KAPPA TOKEN TO COIN");
            // Debug.Log("COIN: "        + amountAddedToWantedCurrency);
            // Debug.Log("KAPPA TOKEN: " + amountAddedToNeededCurrency);
        }
        
        if (wantedCurrency == CurrencyType.KAPPA_TOKEN) // Coin To Kappa Token
        {
            int amountAddedToWantedCurrency = quantityOfWantedCurrency;
            int amountAddedToNeededCurrency = quantityOfWantedCurrency * CoinToKappaToken;
            
            GameManager.Instance.UpdateCurrency(CurrencyType.KAPPA_TOKEN, amountAddedToWantedCurrency);
            GameManager.Instance.UpdateCurrency(CurrencyType.COIN, -amountAddedToNeededCurrency);

            // Debug.Log("COIN TO KAPPA TOKEN");
            // Debug.Log("COIN: "        + amountAddedToNeededCurrency);
            // Debug.Log("KAPPA TOKEN: " + amountAddedToWantedCurrency);

        }
    }

    public static bool CheckForAffordability(CurrencyType wantedCurrency, 
                                             int quantityWanted)
    {
        float affordabilityRatio = 0.0f;

        int currentCurrencyAmount = 0;

        if (wantedCurrency is CurrencyType.COIN)
        {
            // Need to have enough Kappa Tokens
            currentCurrencyAmount = GameManager.Instance.PlayerCurrency.KappaTokens;
        }

        if (wantedCurrency is CurrencyType.KAPPA_TOKEN)
        {
            // Need to have enough Coins
            currentCurrencyAmount = GameManager.Instance.PlayerCurrency.Coins / CoinToKappaToken;
        }
        
        affordabilityRatio = (float) currentCurrencyAmount / quantityWanted;
        return affordabilityRatio >= 1.0f;
    }

    public static int GetAmountWithConversion(CurrencyType wantedCurrency,
                                                        int          quantityOfWantedCurrency)
    {
        int amountOfCurrency = 0;
        if (wantedCurrency is CurrencyType.COIN) // Kappa Token to Coin
        {
            amountOfCurrency = quantityOfWantedCurrency * KappaTokenToCoin;
        }
        
        if (wantedCurrency is CurrencyType.KAPPA_TOKEN) // Coin to Kappa Token
        {
            amountOfCurrency = quantityOfWantedCurrency;
        }
        return amountOfCurrency;
    }

    public static int GetRequiredCurrency(CurrencyType wantedCurrency,
                                                  int          quantityOfWantedCurrency)
    {
        int amountOfRequiredCurrency = 0;
        
        if (wantedCurrency == CurrencyType.COIN) // Kappa Token To Coin
        {
            amountOfRequiredCurrency = quantityOfWantedCurrency;
        }
        
        if (wantedCurrency == CurrencyType.KAPPA_TOKEN) // Coin To Kappa Token
        {
            amountOfRequiredCurrency = quantityOfWantedCurrency * CoinToKappaToken;
        }

        return amountOfRequiredCurrency;
    }
}
