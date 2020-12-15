using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
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

    private AudioSource currentBGM = null;

    private void Update()
    {
        if (currentBGM != null)
        {
            currentBGM.volume = (float)BGMVolume / 100;
        }
    }

    private void Awake()
    {
        Instance = this;
        
        BGMVolume = PlayerPrefs.GetInt("BGM_Volume", maxBGMVolume);
        SFXVolume = PlayerPrefs.GetInt("SFX_Volume", maxSFXVolume);

        currentBGM = GameObject.Find("BGM").GetComponent<AudioSource>();
    }
    
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("BGM_Volume", currentBGMVolume);
        PlayerPrefs.SetInt("SFX_Volume", currentSFXVolume);
    }

    public void PlaySFX(AudioSource audioSource)
    {
        audioSource.loop   = false;
        audioSource.volume = (float)SFXVolume / 100;;
        StartCoroutine(PlayOnBackground(audioSource));
    }
    
    public void PlayBGM(AudioSource audioSource)
    {
        audioSource.loop   = true;
        audioSource.volume = (float)BGMVolume / 100;;
        audioSource.Play();
    }

    public IEnumerator PlayOnBackground(AudioSource audioSource)
    {
        audioSource.Play();
        while (audioSource.isPlaying)
        {
            yield return null;
        }
    }
}
