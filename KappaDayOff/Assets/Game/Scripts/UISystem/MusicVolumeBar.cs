using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeBar : MonoBehaviour
{
	[SerializeField] private TMPro.TMP_Text volumeLabel;

	private Slider volumeSlider;

	private void Awake()
	{
		volumeSlider = GetComponent<Slider>();
	}

	private void OnEnable()
	{
		volumeSlider.value    = AudioHandler.Instance.MusicVolume;
		volumeLabel.text = AudioHandler.Instance.MusicVolume.ToString("F0");
	}

	public void OnMusicVolumeChange(float value)
    {
    	volumeLabel.text           = value.ToString("F0");
    	AudioHandler.Instance.MusicVolume = (int) value;
    }
}
