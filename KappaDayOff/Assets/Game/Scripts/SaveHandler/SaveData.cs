using System;

[Serializable]
public class SaveData
{
	public CurrencyData PlayerCurrency = new CurrencyData();

	public CharacterData PlayerCharacter = new CharacterData();

	public WaterBalloonLauncherData WaterBalloonLauncher = new WaterBalloonLauncherData();
	public AmplifiedSpeakersData    AmplifiedSpeakers    = new AmplifiedSpeakersData();
	public StaticBombData           StaticBomb           = new StaticBombData();

	public LevelData LevelOneProgress = new LevelData();

	public SaveData()
	{
		PlayerCurrency.Coins       = 1000;
		PlayerCurrency.KappaTokens = 3;

		PlayerCharacter.MaxHP   = 50;
		PlayerCharacter.HPLevel = 1;

		PlayerCharacter.BarrierCooldownTime  = 60.0f;
		PlayerCharacter.BarrierCooldownLevel = 1;

		WaterBalloonLauncher.Name          = "Water Balloon Launcher";
		WaterBalloonLauncher.Power         = 1;
		WaterBalloonLauncher.PowerLevel    = 1;
		WaterBalloonLauncher.CooldownTime  = 1.0f;
		WaterBalloonLauncher.CooldownLevel = 1;

		AmplifiedSpeakers.Name              = "Amplified Speakers";
		AmplifiedSpeakers.Power             = 1;
		AmplifiedSpeakers.PowerLevel        = 1;
		AmplifiedSpeakers.CooldownTime      = 1.0f;
		AmplifiedSpeakers.CooldownLevel     = 1;
		AmplifiedSpeakers.PushDistance      = 1.0f;
		AmplifiedSpeakers.PushDistanceLevel = 2;

		StaticBomb.Name                    = "StaticBomb";
		StaticBomb.Power                   = 1;
		StaticBomb.PowerLevel              = 1;
		StaticBomb.CooldownTime            = 1.0f;
		StaticBomb.CooldownLevel           = 1;
		StaticBomb.ImmobilizationTime      = 1.0f;
		StaticBomb.ImmobilizationTimeLevel = 1;

		LevelOneProgress.Name              = "Level 1";
		LevelOneProgress.ProgressLevel     = LevelState.NOT_STARTED;
		LevelOneProgress.HighscoreAchieved = 0;
	}
}