using UnityEngine;

public class GameSettingsHandler
{
    public int BGMVolume => PlayerPrefs.GetInt("BGM_Volume", 100);
    public int SFXVolume => PlayerPrefs.GetInt("SFX_Volume", 100);
}
