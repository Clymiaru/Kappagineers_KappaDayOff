using UnityEngine;

public class AudioHandler : MonoBehaviour
{
	[Header("Audio Handler Properties")]
	[SerializeField]
	private AudioSource soundAudioSource;

	[SerializeField]
	private AudioSource musicAudioSource;

	[SerializeField]
	private int maxMusicVolume = 100;

	[SerializeField]
	private int maxSoundVolume = 100;

	private float currentMusicVolume;
	private float currentSoundVolume;

	public static AudioHandler Instance { get; private set; }

	public float MusicVolume
	{
		get => currentMusicVolume * maxMusicVolume;
		set => currentMusicVolume = Mathf.Clamp(value, 0.0f, maxMusicVolume);
	}

	public float SoundVolume
	{
		get => currentSoundVolume * maxSoundVolume;
		set => currentSoundVolume = Mathf.Clamp(value, 0.0f, maxSoundVolume);
	}

	private void Awake()
	{
		Instance = this;

		MusicVolume = PlayerPrefs.GetFloat(PlayerPrefsKeys.MUSIC_VOLUME, maxMusicVolume);
		SoundVolume = PlayerPrefs.GetFloat(PlayerPrefsKeys.SOUND_VOLUME, maxSoundVolume);
	}

	private void Update()
	{
		musicAudioSource.volume = currentMusicVolume / maxMusicVolume;
	}

	private void OnDestroy()
	{
		PlayerPrefs.SetFloat(PlayerPrefsKeys.MUSIC_VOLUME, currentMusicVolume);
		PlayerPrefs.SetFloat(PlayerPrefsKeys.SOUND_VOLUME, currentSoundVolume);
	}

	public void PlaySound(AudioClip sfx)
	{
		soundAudioSource.volume = currentSoundVolume / maxSoundVolume;
		soundAudioSource.PlayOneShot(sfx);
	}

	public void PlayMusic(AudioSource audioSource)
	{
		audioSource.loop   = true;
		audioSource.volume = currentMusicVolume / maxMusicVolume;
		audioSource.Play();
	}
}
