using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSliderUI : MonoBehaviour
{
    public AudioMixer audioMixer; // Reference to the AudioMixer component
    public AudioSource bgm;

    public Slider MasterSlider; // Reference to the UI Slider component
    public Slider BGMSlider; // Reference to the UI Slider component
    public Slider EffectSlider;
   
    public void SetBGM(AudioClip audioClip)
    {
        bgm.clip = audioClip;
    }

    public void SetMasterVolume()
    {
        PlayerPrefs.SetFloat("MasterVolumeValue", MasterSlider.value);
        audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) *20);
    }

    public void SetBGMVolume()
    {
        PlayerPrefs.SetFloat("BGMVolumeValue", BGMSlider.value);
        audioMixer.SetFloat("BGM", Mathf.Log10(BGMSlider.value) * 20);
    }

    public void SetEffectVolume()
    {
        PlayerPrefs.SetFloat("EffectVolumeValue", EffectSlider.value);
        audioMixer.SetFloat("Effect", Mathf.Log10(EffectSlider.value) * 20);
    }
}

