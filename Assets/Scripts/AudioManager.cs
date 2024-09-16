using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Header("---- Audio Source ----")]
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioSource sfxSource;

    [Header("---- Audio Clip ----")]
    public AudioClip background;
    public AudioClip jumpSfx;
    public AudioClip gameOverSound;
    public AudioClip collectHeartSfx;
    public AudioClip hiscoreSfx;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void PlayBG(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void ToggleMusic()
    {
        audioSource.mute = !audioSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void AudioVolumn(float volumn)
    {
        audioSource.volume = volumn;
    }
    public void SFXVolumn(float volume)
    {
        sfxSource.volume = volume;
    }
}
