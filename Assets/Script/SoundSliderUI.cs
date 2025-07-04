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


    public AudioMixer mixer;
    public Slider masterslider;
    public Slider bgmslider;
    public Slider effectslider;

    public void SetBGM(AudioClip audioClip)
    {
        bgm.clip = audioClip;
    }

    public void SetMasterVolume()
    {
        PlayerPrefs.SetFloat("MasterVolumeValue", MasterSlider.value);
        audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) *20);
        PlayerPrefs.SetFloat("MasterVolume", MasterSlider.value);
    }

    public void SetBGMVolume()
    {
        PlayerPrefs.SetFloat("BGMVolumeValue", BGMSlider.value);
        audioMixer.SetFloat("BGM", Mathf.Log10(BGMSlider.value) * 20);
        PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
    }

    public void SetEffectVolume()
    {
        PlayerPrefs.SetFloat("EffectVolumeValue", EffectSlider.value);
        audioMixer.SetFloat("Effect", Mathf.Log10(EffectSlider.value) * 20);
        PlayerPrefs.SetFloat("EffectVolume", EffectSlider.value);
    }

    public void OnEnable()
    {
        masterslider.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        bgmslider.value = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        effectslider.value = PlayerPrefs.GetFloat("EffectVolume", 0.5f);
    }

    public void OnDisable()
    {
        masterslider.onValueChanged.RemoveAllListeners();
        bgmslider.onValueChanged.RemoveAllListeners();
        effectslider.onValueChanged.RemoveAllListeners();
    }

    public void SetLevel(float sliderValue)
    {
       mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
       PlayerPrefs.SetFloat("MasterVolume", sliderValue);
     
    }

 
}

