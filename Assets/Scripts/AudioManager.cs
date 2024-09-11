using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
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
    public void PlaySFX(AudioClip clip){
        sfxSource.PlayOneShot(clip);
    }
    public void PlayBG(AudioClip clip){
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void StopMusic(){
        audioSource.Stop();
    }
}
