using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	public SaveData PlayerData { get; private set; }

	public bool IsPaused { get; } = false;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		SaveDataManager.Instance.Load();

		PlayerData = SaveDataManager.Instance.PlayerSaveData;

		Parameters parameters = new Parameters();
		parameters.PutExtra("KappaTokens", SaveDataManager.Instance.PlayerSaveData.PlayerCurrency.KappaTokens);
		parameters.PutExtra("Coins", SaveDataManager.Instance.PlayerSaveData.PlayerCurrency.Coins);

		EventBroadcaster.Instance.PostEvent(EventNames.Currency.ON_SET_CURRENCY, parameters);
	}

	private void OnDestroy()
	{
		SaveDataManager.Instance.Save();
	}

	public void UpdateCurrency(CurrencyType currency, int amountAdded)
	{
		if (currency == CurrencyType.COIN)
		{
			var coins = PlayerData.PlayerCurrency.Coins;
			PlayerData.PlayerCurrency.Coins += amountAdded;
			PlayerData.PlayerCurrency.Coins =  Mathf.Max(PlayerData.PlayerCurrency.Coins, 0);
		}
		else if (currency == CurrencyType.KAPPA_TOKEN)
		{
			var kappaTokens = PlayerData.PlayerCurrency.KappaTokens;
			PlayerData.PlayerCurrency.KappaTokens += amountAdded;
			PlayerData.PlayerCurrency.KappaTokens =  Mathf.Max(PlayerData.PlayerCurrency.KappaTokens, 0);
		}

		Parameters parameters = new Parameters();
		parameters.PutExtra("KappaTokens", SaveDataManager.Instance.PlayerSaveData.PlayerCurrency.KappaTokens);
		parameters.PutExtra("Coins", SaveDataManager.Instance.PlayerSaveData.PlayerCurrency.Coins);

		EventBroadcaster.Instance.PostEvent(EventNames.Currency.ON_SET_CURRENCY, parameters);
	}


	#region Developer Options
	// TODO: Ask if a debug option is chosen, does it save to the player data?
	public void GenerateNotification()
	{
	}

	public void UnlockAllLevels()
	{
	}

	public void UnlimitedMoney()
	{
		PlayerData.PlayerCurrency.Coins       = 9999999;
		PlayerData.PlayerCurrency.KappaTokens = 9999999;

		SaveDataManager.Instance.Save();

		Parameters parameters = new Parameters();
		parameters.PutExtra("KappaTokens", SaveDataManager.Instance.PlayerSaveData.PlayerCurrency.KappaTokens);
		parameters.PutExtra("Coins", SaveDataManager.Instance.PlayerSaveData.PlayerCurrency.Coins);

		EventBroadcaster.Instance.PostEvent(EventNames.Currency.ON_SET_CURRENCY, parameters);

		Debug.Log("DEBUG: Unlimited Money");
	}

	public void ResetPlayerProgress()
	{
		SaveDataManager.Instance.ResetProgress();
		PlayerData = SaveDataManager.Instance.PlayerSaveData;

		Parameters parameters = new Parameters();
		parameters.PutExtra("KappaTokens", SaveDataManager.Instance.PlayerSaveData.PlayerCurrency.KappaTokens);
		parameters.PutExtra("Coins", SaveDataManager.Instance.PlayerSaveData.PlayerCurrency.Coins);

		EventBroadcaster.Instance.PostEvent(EventNames.Currency.ON_SET_CURRENCY, parameters);
	}

	public void ChangeTimeOfDay()
	{
	}
	#endregion
}
