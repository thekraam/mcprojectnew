using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	// Audio players components.
	public AudioSource EffectsSource;
	public AudioSource MusicSource;

	public AudioClip oldMusicClip;
	public AudioClip oldEffectClip;

	public static AudioManager Instance = null;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	public void ResetAudio()
    {
		MusicSource.Stop();
		EffectsSource.Stop();
		MusicSource.volume = 1;
		EffectsSource.volume = 1;
	}

	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}

	public void StopMusic(AudioClip clip)
	{
		StartCoroutine(FadeOut(true, clip));
	}
	IEnumerator FadeOut(bool isMusic, AudioClip clip)
	{
		bool stop = false;

		if (isMusic)
		{
			while (!stop)
			{
				MusicSource.volume -= 0.005f;
				if (MusicSource.volume <= 0) stop = true;
				yield return new WaitForSeconds(0.008f);
			}
			MusicSource.Stop();
		}
        else
        {
			while (!stop)
			{
				Debug.LogError("dentro il decremento");
				EffectsSource.volume -= 0.005f;
				if (EffectsSource.volume <= 0) stop = true;
				yield return new WaitForSeconds(0.008f);
			}
			EffectsSource.Stop();
		}
		MusicSource.volume = 1;
		EffectsSource.volume = 1;
	}

	public void PlayEffect(AudioClip clip)
	{
		StopAllCoroutines();
		ResetAudio();
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}

	public void PlayEffectFaded(AudioClip clip)
    {
		StopAllCoroutines();
		ResetAudio();
		PlayEffect(clip);
		StartCoroutine(FadeOut(false, clip));
    }

	public void RandomSoundEffect(params AudioClip[] clips)
	{
		StopAllCoroutines();
		ResetAudio();
		int randomIndex = Random.Range(0, clips.Length);
		EffectsSource.clip = clips[randomIndex];

		oldEffectClip = EffectsSource.clip;
		EffectsSource.Play();
	}
	public void RandomMusic(params AudioClip[] clips)
	{
		StopAllCoroutines();
		ResetAudio();
		int randomIndex = Random.Range(0, clips.Length);
		MusicSource.clip = clips[randomIndex];

		oldMusicClip = MusicSource.clip;
		MusicSource.Play();
	}
}