using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TMP_Text;

public class SettingsScreen : MonoBehaviour
{
	[SerializeField] private List<Button> optionButtons = new List<Button>();

	[Header("Sound Options"), SerializeField]

     private GameObject soundOptionsPanel;

	[SerializeField] private Slider musicVolumeSlider;
	[SerializeField] private Text   musicVolumeLabel;
	[SerializeField] private Slider sfxVolumeSlider;
	[SerializeField] private Text   sfxVolumeLabel;

	[Header("Credits"), SerializeField]
     private GameObject creditsPanel;

	[Header("Debug Options"), SerializeField]
     private GameObject debugOptionsPanel;

	[SerializeField] private AudioSource tapSFX;
	[SerializeField] private AudioSource successSFX;

	private GameObject currentPanelSelected;

	private int optionIndex; // For now, auto-select the first option

	private void Start()
	{
		optionIndex = 0;
		optionButtons[optionIndex].Select();
		currentPanelSelected = soundOptionsPanel.gameObject;

		musicVolumeLabel.text   = AudioHandler.Instance.MusicVolume.ToString("F0");
		musicVolumeSlider.value = AudioHandler.Instance.MusicVolume;

		sfxVolumeLabel.text   = AudioHandler.Instance.SoundVolume.ToString("F0");
		sfxVolumeSlider.value = AudioHandler.Instance.SoundVolume;
	}

	private void Update()
	{
		optionButtons[optionIndex].Select();

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			OnExitScreen();
		}
	}

	#region Credits
	public void OnCreditsSelect()
	{
		// AudioHandler.Instance.PlaySound(tapSFX);
		currentPanelSelected.SetActive(false);
		currentPanelSelected = creditsPanel.gameObject;
		currentPanelSelected.SetActive(true);
		optionIndex = 1;
	}
	#endregion

	public void OnExitScreen()
	{
		// AudioHandler.Instance.PlaySound(tapSFX);

		gameObject.SetActive(false);
		currentPanelSelected.SetActive(false);

		currentPanelSelected = soundOptionsPanel.gameObject;
		currentPanelSelected.SetActive(true);
		optionIndex = 0;
	}

	#region Sound Options
	public void OnSoundOptionsSelect()
	{
		// AudioHandler.Instance.PlaySound(tapSFX);
		currentPanelSelected.SetActive(false);
		currentPanelSelected = soundOptionsPanel.gameObject;
		currentPanelSelected.SetActive(true);
		optionIndex = 0;
	}

	public void OnMusicVolumeChange(float value)
	{
		musicVolumeLabel.text           = value.ToString("F0");
		AudioHandler.Instance.MusicVolume = (int) value;
	}

	public void OnSFXVolumeChange(float value)
	{
		sfxVolumeLabel.text             = value.ToString("F0");
		AudioHandler.Instance.SoundVolume = (int) value;
	}
	#endregion

	#region Debug Options
	public void OnDebugOptionsSelect()
	{
		// AudioHandler.Instance.PlaySound(tapSFX);
		currentPanelSelected.SetActive(false);
		currentPanelSelected = debugOptionsPanel.gameObject;
		currentPanelSelected.SetActive(true);
		optionIndex = 2;
	}

	public void OnUnlockAllLevels()
	{
		// AudioHandler.Instance.PlaySound(successSFX);
	}

	public void OnUnlimitedMoney()
	{
		// AudioHandler.Instance.PlaySound(successSFX);
		GameManager.Instance.UnlimitedMoney();
	}

	public void OnResetPlayerProgress()
	{
		// AudioHandler.Instance.PlaySound(successSFX);
		GameManager.Instance.ResetPlayerProgress();
	}

	public void OnChangeTimeOfDay()
	{
		// AudioHandler.Instance.PlaySound(successSFX);
	}

	public void GenerateNotifications()
	{
		// AudioHandler.Instance.PlaySound(successSFX);
	}

	public void GenerateNotificationsAtInterval()
	{
		// AudioHandler.Instance.PlaySound(successSFX);
	}
	#endregion
}
