using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

using Text = TMPro.TMP_Text;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField] private List<Button> optionButtons = new List<Button>();
    
    [Header("Sound Options")] 
    
    [SerializeField] private GameObject soundOptionsPanel = null;
    [SerializeField] private Slider musicVolumeSlider = null;
    [SerializeField] private Text   musicVolumeLabel  = null;
    [SerializeField] private Slider sfxVolumeSlider   = null;
    [SerializeField] private Text   sfxVolumeLabel    = null;
    
    [Header("Credits")] 
    [SerializeField] private GameObject creditsPanel = null;
    
    [Header("Debug Options")] 
    [SerializeField] private GameObject debugOptionsPanel = null;
    
    [SerializeField] private AudioSource tapSFX     = null;
    [SerializeField] private AudioSource successSFX = null;

    private GameObject currentPanelSelected = null;

    public AdsManager adsManager;
    
    private int optionIndex = 0; // For now, auto-select the first option
    
    private void Start()
    {
        optionIndex = 0;
        optionButtons[optionIndex].Select();
        currentPanelSelected = soundOptionsPanel.gameObject;
        
        musicVolumeLabel.text   = AudioHandler.Instance.BGMVolume.ToString("F0");
        musicVolumeSlider.value = AudioHandler.Instance.BGMVolume;
        
        sfxVolumeLabel.text     = AudioHandler.Instance.SFXVolume.ToString("F0");
        sfxVolumeSlider.value = AudioHandler.Instance.SFXVolume;
    }

    private void Update()
    {
        optionButtons[optionIndex].Select();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnExitScreen();
        }
    }

    #region Sound Options

    public void OnSoundOptionsSelect()
    {
        AudioHandler.Instance.PlaySFX(tapSFX);
        currentPanelSelected.SetActive(false);
        currentPanelSelected = soundOptionsPanel.gameObject;
        currentPanelSelected.SetActive(true);
        optionIndex = 0;
    }

    public void OnMusicVolumeChange(float value)
    {
        musicVolumeLabel.text           = value.ToString("F0");
        AudioHandler.Instance.BGMVolume = (int)value;
    }
    
    public void OnSFXVolumeChange(float value)
    {
        sfxVolumeLabel.text             = value.ToString("F0");
        AudioHandler.Instance.SFXVolume = (int)value;
    }

    #endregion
    
    #region Credits
    
    public void OnCreditsSelect()
    {
        AudioHandler.Instance.PlaySFX(tapSFX);
        currentPanelSelected.SetActive(false);
        currentPanelSelected = creditsPanel.gameObject;
        currentPanelSelected.SetActive(true);
        optionIndex = 1;
    }


    #endregion
    
    #region Debug Options
    public void OnDebugOptionsSelect()
    {
        AudioHandler.Instance.PlaySFX(tapSFX);
        currentPanelSelected.SetActive(false);
        currentPanelSelected = debugOptionsPanel.gameObject;
        currentPanelSelected.SetActive(true);
        optionIndex = 2;
    }

    public void OnUnlockAllLevels()
    {
        AudioHandler.Instance.PlaySFX(successSFX);
    }
    
    public void OnUnlimitedMoney()
    {
        AudioHandler.Instance.PlaySFX(successSFX);
        GameManager.Instance.UnlimitedMoney();
    }
    
    public void OnResetPlayerProgress()
    {
        AudioHandler.Instance.PlaySFX(successSFX);
        GameManager.Instance.ResetPlayerProgress();
    }

    public void OnChangeTimeOfDay()
    {
        AudioHandler.Instance.PlaySFX(successSFX);
    }

    public void GenerateNotifications()
    {
        AudioHandler.Instance.PlaySFX(successSFX);
    }

    public void GenerateNotificationsAtInterval()
    {
        AudioHandler.Instance.PlaySFX(successSFX);
    }
    
    #endregion

    public void OnExitScreen()
    {
        AudioHandler.Instance.PlaySFX(tapSFX);
        
        gameObject.SetActive(false);
        currentPanelSelected.SetActive(false);
        
        currentPanelSelected = soundOptionsPanel.gameObject;
        currentPanelSelected.SetActive(true);
        optionIndex = 0;

        adsManager.HideBannerAd();
    }
}
