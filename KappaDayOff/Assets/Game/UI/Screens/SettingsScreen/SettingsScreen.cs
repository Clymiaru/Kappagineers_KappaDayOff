using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

using Text = TMPro.TMP_Text;

public class SettingsScreen : MonoBehaviour
{
    // TODO: Handle option values and store in playerPrefs

    [SerializeField] private List<Button> optionButtons = new List<Button>();
    
    [Header("Sound Options")] 
    
    [SerializeField] private GameObject soundOptionsPanel = null;
    [SerializeField] private Text musicVolumeLabel = null;
    [SerializeField] private Text sfxVolumeLabel   = null;
    
    [Header("Credits")] 
    [SerializeField] private GameObject creditsPanel = null;
    
    [Header("Debug Options")] 
    [SerializeField] private GameObject debugOptionsPanel = null;

    private GameObject currentPanelSelected = null;
    
    private int optionIndex = 0; // For now, auto-select the first option
    
    private void Start()
    {
        optionIndex = 0;
        optionButtons[optionIndex].Select();
        currentPanelSelected = soundOptionsPanel.gameObject;
    }

    private void Update()
    {
        optionButtons[optionIndex].Select();
        
    }

    #region Sound Options

    public void OnSoundOptionsSelect()
    {
        currentPanelSelected.SetActive(false);
        currentPanelSelected = soundOptionsPanel.gameObject;
        currentPanelSelected.SetActive(true);
        optionIndex = 0;
    }

    public void OnMusicVolumeChange(float value)
    {
        // Send to the sound manager/handler
        musicVolumeLabel.text = value.ToString("F0");
    }
    
    public void OnSFXVolumeChange(float value)
    {
        // Send to the sound manager/handler
        sfxVolumeLabel.text = value.ToString("F0");
    }

    #endregion
    
    #region Credits
    
    public void OnCreditsSelect()
    {
        currentPanelSelected.SetActive(false);
        currentPanelSelected = creditsPanel.gameObject;
        currentPanelSelected.SetActive(true);
        optionIndex = 1;
    }


    #endregion
    
    #region Debug Options
    public void OnDebugOptionsSelect()
    {
        currentPanelSelected.SetActive(false);
        currentPanelSelected = debugOptionsPanel.gameObject;
        currentPanelSelected.SetActive(true);
        optionIndex = 2;
    }

    #endregion

    public void OnExitScreen()
    {
        gameObject.SetActive(false);
        currentPanelSelected.SetActive(false);
        OnSoundOptionsSelect();
    }
}
