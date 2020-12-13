using UnityEngine;

public enum LevelState
{
    NOT_STARTED,
    IN_PROGRESSED,
    COMPLETED
}

[System.Serializable]
public class LevelData
{
    public string     Name;
    public LevelState ProgressLevel;
    public int        HighscoreAchieved;
}
