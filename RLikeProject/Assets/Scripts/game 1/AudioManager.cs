using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
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

		//DontDestroyOnLoad(gameObject);
	}

	public void ResetAudioEffects()
	{
		EffectsSource.Stop();
		EffectsSource.volume = 1;
	}

	public void ResetAudioMusic()
	{
		MusicSource.Stop();
		MusicSource.volume = 1;
	}

	public void PlayMusic(AudioClip clip)
	{
		if (!MusicSource.isPlaying)
		{
			MusicSource.clip = clip;
			MusicSource.Play();
		}
	}

	public void StopMusic(AudioClip clip)
	{
		StartCoroutine(FadeOut(true, clip));
	}
	IEnumerator FadeOut(bool isMusic, AudioClip clip)
	{
		if (isMusic)
		{
			while (MusicSource.volume > 0)
			{
				MusicSource.volume -= 0.005f;
				yield return new WaitForSeconds(0.004f);
			}
			MusicSource.Stop();
			MusicSource.volume = 1;
		}
		else
		{
			while (EffectsSource.volume > 0)
			{
				EffectsSource.volume -= 0.005f;
				yield return new WaitForSeconds(0.008f);
			}
			EffectsSource.Stop();
		}
		EffectsSource.volume = 1;
	}

	public void PlayEffect(AudioClip clip)
	{
		if ((EffectsSource.isPlaying && EffectsSource.clip != clip) || (!EffectsSource.isPlaying))
		{
			StopAllCoroutines();
			ResetAudioEffects();
			EffectsSource.clip = clip;
			EffectsSource.Play();
		}
	}

	public void PlayEffectFaded(AudioClip clip)
	{
		if ((EffectsSource.isPlaying && EffectsSource.clip != clip) || (!EffectsSource.isPlaying))
		{
			StopAllCoroutines();
			ResetAudioEffects();
			PlayEffect(clip);
			StartCoroutine(FadeOut(false, clip));
		}
	}

	public void RandomSoundEffect(params AudioClip[] clips)
	{
		StopAllCoroutines();
		ResetAudioEffects();
		int randomIndex = Random.Range(0, clips.Length);
		EffectsSource.clip = clips[randomIndex];
		if (oldEffectClip == EffectsSource.clip && randomIndex > 0) EffectsSource.clip = clips[randomIndex - 1];
		if (oldEffectClip == EffectsSource.clip && randomIndex == 0) EffectsSource.clip = clips[randomIndex + 1];

		oldEffectClip = EffectsSource.clip;
		EffectsSource.Play();
	}
	public void RandomMusic(params AudioClip[] clips)
	{
		if (!MusicSource.isPlaying)
		{
			StopAllCoroutines();
			MusicSource.volume = 0.1f;
			int randomIndex = Random.Range(0, clips.Length);
			MusicSource.clip = clips[randomIndex];
			if (oldMusicClip == MusicSource.clip && randomIndex > 0) MusicSource.clip = clips[randomIndex - 1];
			if (oldMusicClip == MusicSource.clip && randomIndex == 0) MusicSource.clip = clips[randomIndex + 1];

			oldMusicClip = MusicSource.clip;
			MusicSource.Play();
		}
	}
}