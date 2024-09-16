using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMenuUI : MonoBehaviour
{
    public Slider audioSlider, sfxSlider;

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }
    public void AudioVolumn()
    {
        AudioManager.Instance.AudioVolumn(audioSlider.value);
    }
    public void SFXVolumn()
    {
        AudioManager.Instance.SFXVolumn(sfxSlider.value);
    }
}
