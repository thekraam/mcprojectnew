using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource EffectsSource;
	public AudioSource MusicSource;

	public AudioClip oldMusicClip;
	public AudioClip oldEffectClip;

	public GameObject MuteButton;

	public static AudioManager Instance = null;
	private bool muted = false;

	public void Mute()
    {
		if (!muted)
        {
			//MusicSource.Stop();
			//EffectsSource.Stop();
			MusicSource.volume = 0;
			EffectsSource.volume = 0;
			muted = true;
        }
        else
        {
			//MusicSource.Stop();
			//EffectsSource.Stop();
			MusicSource.volume = 1;
			EffectsSource.volume = 1;
			muted = false;
        }
			
    }

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
		DontDestroyOnLoad(MuteButton);
	}

	public void ResetAudioEffects()
	{
		if (!muted)
		{
			EffectsSource.Stop();
			EffectsSource.volume = 1;
		}
	}

	public void ResetAudioMusic()
	{
		if (!muted)
		{
			MusicSource.Stop();
			MusicSource.volume = 1;
		}
	}

	public void ForcePlayMusic(AudioClip clip)
    {
		StartCoroutine(ForcePlayMusicExecuter(clip));
    }

	IEnumerator ForcePlayMusicExecuter(AudioClip clip)
    {
		yield return new WaitUntil(() => MusicSource.isPlaying == false);
		MusicSource.clip = clip;
		MusicSource.Play();
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
		if (!muted)
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

	public AudioClip SelectRandomClip(params AudioClip[] clips)
    {
		int randomIndex = Random.Range(0, clips.Length);
		AudioClip randomClip;
		randomClip = clips[randomIndex];
		if (oldMusicClip == randomClip && randomIndex > 0) randomClip = clips[randomIndex - 1];
		if (oldMusicClip == randomClip && randomIndex == 0) randomClip = clips[randomIndex + 1];
		oldMusicClip = randomClip;

		return randomClip;
	}

	public void RandomMusic(params AudioClip[] clips)
	{
		if (!muted)
		{
			if (!MusicSource.isPlaying)
			{
				StopAllCoroutines();
				MusicSource.volume = 1f;
				int randomIndex = Random.Range(0, clips.Length);
				MusicSource.clip = clips[randomIndex];
				if (oldMusicClip == MusicSource.clip && randomIndex > 0) MusicSource.clip = clips[randomIndex - 1];
				if (oldMusicClip == MusicSource.clip && randomIndex == 0) MusicSource.clip = clips[randomIndex + 1];

				oldMusicClip = MusicSource.clip;
				MusicSource.Play();
			}
		}
	}
}