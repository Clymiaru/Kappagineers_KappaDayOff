using UnityEngine;

public class GameManager : MonoBehaviour
{
	private const string PlayerSaveFileName = "player";

	public static GameManager Instance { get; private set; }

	public bool IsPaused { get; } = false;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		InitializePlayerData();
	}

	private void OnDestroy()
	{
		SavePlayerData();
	}

	public void UpdateCurrency(CurrencyType currency, int amountAdded)
	{
		if (currency == CurrencyType.COIN)
		{
			PlayerCurrency.Coins += amountAdded;
			PlayerCurrency.Coins =  Mathf.Max(PlayerCurrency.Coins, 0);
		}
		else if (currency == CurrencyType.KAPPA_TOKEN)
		{
			PlayerCurrency.KappaTokens += amountAdded;
			PlayerCurrency.KappaTokens =  Mathf.Max(PlayerCurrency.KappaTokens, 0);
		}
	}

	public void InitializePlayerData()
	{
		SaveData playerData = SaveHandler.Instance.Load(PlayerSaveFileName);

		if (playerData == null)
		{
			playerData = CreateNewPlayerSave();
		}

		PlayerCurrency.Coins       = playerData.PlayerCurrency.Coins;
		PlayerCurrency.KappaTokens = playerData.PlayerCurrency.KappaTokens;

		PlayerCharacter.MaxHP   = playerData.PlayerCharacter.MaxHP;
		PlayerCharacter.HPLevel = playerData.PlayerCharacter.HPLevel;

		PlayerCharacter.BarrierCooldownTime  = playerData.PlayerCharacter.BarrierCooldownTime;
		PlayerCharacter.BarrierCooldownLevel = playerData.PlayerCharacter.BarrierCooldownLevel;

		WaterBalloonLauncher.Power         = playerData.WaterBalloonLauncher.Power;
		WaterBalloonLauncher.PowerLevel    = playerData.WaterBalloonLauncher.PowerLevel;
		WaterBalloonLauncher.CooldownTime  = playerData.WaterBalloonLauncher.CooldownTime;
		WaterBalloonLauncher.CooldownLevel = playerData.WaterBalloonLauncher.CooldownLevel;

		AmplifiedSpeakers.Power             = playerData.AmplifiedSpeakers.Power;
		AmplifiedSpeakers.PowerLevel        = playerData.AmplifiedSpeakers.PowerLevel;
		AmplifiedSpeakers.CooldownTime      = playerData.AmplifiedSpeakers.CooldownTime;
		AmplifiedSpeakers.CooldownLevel     = playerData.AmplifiedSpeakers.CooldownLevel;
		AmplifiedSpeakers.PushDistance      = playerData.AmplifiedSpeakers.PushDistance;
		AmplifiedSpeakers.PushDistanceLevel = playerData.AmplifiedSpeakers.PushDistanceLevel;

		StaticBomb.Power                   = playerData.StaticBomb.Power;
		StaticBomb.PowerLevel              = playerData.StaticBomb.PowerLevel;
		StaticBomb.CooldownTime            = playerData.StaticBomb.CooldownTime;
		StaticBomb.CooldownLevel           = playerData.StaticBomb.CooldownLevel;
		StaticBomb.ImmobilizationTime      = playerData.StaticBomb.ImmobilizationTime;
		StaticBomb.ImmobilizationTimeLevel = playerData.StaticBomb.ImmobilizationTimeLevel;

		LevelOneProgress.ProgressLevel     = playerData.LevelOneProgress.ProgressLevel;
		LevelOneProgress.HighscoreAchieved = playerData.LevelOneProgress.HighscoreAchieved;
	}

	private SaveData CreateNewPlayerSave()
	{
		var playerData = new SaveData();
		SaveHandler.Instance.Save(playerData, PlayerSaveFileName);
		return playerData;
	}

	public void SavePlayerData()
	{
		var playerData = new SaveData();

		playerData.PlayerCurrency.Coins       = PlayerCurrency.Coins;
		playerData.PlayerCurrency.KappaTokens = PlayerCurrency.KappaTokens;

		playerData.PlayerCharacter.MaxHP   = PlayerCharacter.MaxHP;
		playerData.PlayerCharacter.HPLevel = PlayerCharacter.HPLevel;

		playerData.PlayerCharacter.BarrierCooldownTime  = PlayerCharacter.BarrierCooldownTime;
		playerData.PlayerCharacter.BarrierCooldownLevel = PlayerCharacter.BarrierCooldownLevel;

		playerData.WaterBalloonLauncher.Power         = WaterBalloonLauncher.Power;
		playerData.WaterBalloonLauncher.PowerLevel    = WaterBalloonLauncher.PowerLevel;
		playerData.WaterBalloonLauncher.CooldownTime  = WaterBalloonLauncher.CooldownTime;
		playerData.WaterBalloonLauncher.CooldownLevel = WaterBalloonLauncher.CooldownLevel;

		playerData.AmplifiedSpeakers.Power             = AmplifiedSpeakers.Power;
		playerData.AmplifiedSpeakers.PowerLevel        = AmplifiedSpeakers.PowerLevel;
		playerData.AmplifiedSpeakers.CooldownTime      = AmplifiedSpeakers.CooldownTime;
		playerData.AmplifiedSpeakers.CooldownLevel     = AmplifiedSpeakers.CooldownLevel;
		playerData.AmplifiedSpeakers.PushDistance      = AmplifiedSpeakers.PushDistance;
		playerData.AmplifiedSpeakers.PushDistanceLevel = AmplifiedSpeakers.PushDistanceLevel;

		playerData.StaticBomb.Power                   = StaticBomb.Power;
		playerData.StaticBomb.PowerLevel              = StaticBomb.PowerLevel;
		playerData.StaticBomb.CooldownTime            = StaticBomb.CooldownTime;
		playerData.StaticBomb.CooldownLevel           = StaticBomb.CooldownLevel;
		playerData.StaticBomb.ImmobilizationTime      = StaticBomb.ImmobilizationTime;
		playerData.StaticBomb.ImmobilizationTimeLevel = StaticBomb.ImmobilizationTimeLevel;

		playerData.LevelOneProgress.ProgressLevel     = LevelOneProgress.ProgressLevel;
		playerData.LevelOneProgress.HighscoreAchieved = LevelOneProgress.HighscoreAchieved;

		SaveHandler.Instance.Save(playerData, PlayerSaveFileName);
	}

	#region Global Game Data
	public CurrencyData             PlayerCurrency       { get; } = new CurrencyData();
	public CharacterData            PlayerCharacter      { get; } = new CharacterData();
	public WaterBalloonLauncherData WaterBalloonLauncher { get; } = new WaterBalloonLauncherData();
	public AmplifiedSpeakersData    AmplifiedSpeakers    { get; } = new AmplifiedSpeakersData();
	public StaticBombData           StaticBomb           { get; } = new StaticBombData();
	public LevelData                LevelOneProgress     { get; } = new LevelData();
	#endregion

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
		PlayerCurrency.Coins       = int.MaxValue;
		PlayerCurrency.KappaTokens = int.MaxValue;
		Debug.Log("DEBUG: Unlimited Money");
	}

	public void ResetPlayerProgress()
	{
		PlayerCurrency.Coins       = 1000;
		PlayerCurrency.KappaTokens = 3;

		PlayerCharacter.MaxHP   = 50;
		PlayerCharacter.HPLevel = 1;

		PlayerCharacter.BarrierCooldownTime  = 60;
		PlayerCharacter.BarrierCooldownLevel = 1;

		WaterBalloonLauncher.Power         = 10;
		WaterBalloonLauncher.PowerLevel    = 1;
		WaterBalloonLauncher.CooldownTime  = 1.0f;
		WaterBalloonLauncher.CooldownLevel = 1;

		AmplifiedSpeakers.Power             = 10;
		AmplifiedSpeakers.PowerLevel        = 1;
		AmplifiedSpeakers.CooldownTime      = 1.0f;
		AmplifiedSpeakers.CooldownLevel     = 1;
		AmplifiedSpeakers.PushDistance      = 1.0f;
		AmplifiedSpeakers.PushDistanceLevel = 1;

		StaticBomb.Power                   = 1;
		StaticBomb.PowerLevel              = 1;
		StaticBomb.CooldownTime            = 1;
		StaticBomb.CooldownLevel           = 1;
		StaticBomb.ImmobilizationTime      = 0.2f;
		StaticBomb.ImmobilizationTimeLevel = 1;

		LevelOneProgress.ProgressLevel     = LevelState.NOT_STARTED;
		LevelOneProgress.HighscoreAchieved = 0;

		Debug.Log("DEBUG: Reset Player Progress");
	}

	public void ChangeTimeOfDay()
	{
	}

	public void NotificationInterval()
	{
	}
	#endregion
}