using UnityEngine;

using Image = UnityEngine.UI.Image;
using Text = TMPro.TMP_Text;

public class ExchangeScreen : MonoBehaviour
{
    public CurrencyType WantedCurrency = CurrencyType.COIN;

    private int quantityOfWantedCurrency = 0;
    
    private const int defaultAmountOfCurrency = 0;
    
    #region Currency Icons

    [Header("Currency Icons")]
    
    [SerializeField] private Sprite coinsIcon       = null;
    [SerializeField] private Sprite kappaTokensIcon = null;
    
    
    #endregion
    
    [Header("Wanted Currency")]
    
    #region Wanted Currency
    
    [SerializeField] private Image wantedCurrencyIcon = null;
    [SerializeField] private Text  wantedCurrencyText = null;
    
    #endregion
    
    #region Needed Currency Controls
    
    [Header("Needed Currency")]
    
    [SerializeField] private Image neededCurrencyIcon = null;
    [SerializeField] private Text  neededCurrencyText = null;
    
    #endregion


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
        CurrencyExchanger.CommenceExchange(WantedCurrency, 
                                           quantityOfWantedCurrency);
        quantityOfWantedCurrency = 0;
        ResetScreen();
    }

    public void OnAddWantedCurrency()
    {
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
        neededCurrencyText.text = rawAmountOfNeededCurrency.ToString();
    }

    private void ResetScreen()
    {
        quantityOfWantedCurrency = defaultAmountOfCurrency;
        wantedCurrencyText.text  = defaultAmountOfCurrency.ToString();
        neededCurrencyText.text  = defaultAmountOfCurrency.ToString();
    }
    
    public void OnExitScreen()
    {
        ResetScreen();
        gameObject.SetActive(false);
    }
}
