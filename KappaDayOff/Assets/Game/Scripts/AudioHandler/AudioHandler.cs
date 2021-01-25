using UnityEngine;

public class AudioHandler : MonoBehaviour
{
	private readonly AudioSource currentBGM = null;
	private          int         currentBGMVolume;
	private          int         currentSFXVolume;

	private readonly int maxBGMVolume = 100;

	private readonly int maxSFXVolume = 100;

	public static AudioHandler Instance { get; private set; }

	public int BGMVolume
	{
		get => currentBGMVolume;
		set => currentBGMVolume = Mathf.Clamp(value, 0, maxBGMVolume);
	}

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

		// currentBGM = GameObject.Find("BGM").GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (currentBGM != null)
		{
			currentBGM.volume = (float) BGMVolume / 100;
		}
	}

	private void OnDestroy()
	{
		PlayerPrefs.SetInt("BGM_Volume", currentBGMVolume);
		PlayerPrefs.SetInt("SFX_Volume", currentSFXVolume);
	}

	public void PlaySFX(AudioSource audioSource)
	{
		audioSource.loop   = false;
		audioSource.volume = (float) SFXVolume / 100;
		;
		audioSource.Play();
	}

	public void PlayBGM(AudioSource audioSource)
	{
		audioSource.loop   = true;
		audioSource.volume = (float) BGMVolume / 100;
		;
		audioSource.Play();
	}
}
