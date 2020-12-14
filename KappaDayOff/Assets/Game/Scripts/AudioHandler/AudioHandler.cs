using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private static AudioHandler sharedInstance = null;
    public static AudioHandler Instance
    {
        get => sharedInstance;
        private set => sharedInstance = value;
    }

    private int maxBGMVolume = 100;
    private int currentBGMVolume = 0;
    public int BGMVolume
    {
        get => currentBGMVolume;
        set => currentBGMVolume = Mathf.Clamp(value, 0, maxBGMVolume);
    }
    
    private int maxSFXVolume     = 100;
    private int currentSFXVolume = 0;
    public int SFXVolume
    {
        get => currentSFXVolume;
        set => currentSFXVolume = Mathf.Clamp(value, 0, maxSFXVolume);
    }
    
    private void Awake()
    {
        Instance = this;
        
        BGMVolume = PlayerPrefs.GetInt("BGM_Volume", maxBGMVolume);
        SFXVolume = PlayerPrefs.GetInt("SFX_Volume", maxSFXVolume);
    }
    
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("BGM_Volume", currentBGMVolume);
        PlayerPrefs.SetInt("SFX_Volume", currentSFXVolume);
    }
}
