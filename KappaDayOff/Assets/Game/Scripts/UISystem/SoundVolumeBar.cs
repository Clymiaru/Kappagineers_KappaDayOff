using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeBar : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text volumeLabel;

    private Slider volumeSlider;

    private void Awake()
    {
        volumeSlider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        volumeSlider.value    = AudioHandler.Instance.SoundVolume;
        volumeLabel.text = AudioHandler.Instance.SoundVolume.ToString("F0");
    }

    public void OnSoundVolumeChange(float value)
    {
        volumeLabel.text                  = value.ToString("F0");
        AudioHandler.Instance.SoundVolume = (int) value;
    }
}
