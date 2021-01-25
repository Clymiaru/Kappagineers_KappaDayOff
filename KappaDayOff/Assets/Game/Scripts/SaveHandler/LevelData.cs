using System;

public enum LevelState
{
	NOT_STARTED,
	IN_PROGRESSED,
	COMPLETED
}

[Serializable]
public class LevelData
{
	public string     Name;
	public LevelState ProgressLevel;
	public int        HighscoreAchieved;
}