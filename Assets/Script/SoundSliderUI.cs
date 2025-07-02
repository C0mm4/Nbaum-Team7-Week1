using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSliderUI : MonoBehaviour
{
    public AudioMixer audioMixer; // Reference to the AudioMixer component

    public Slider MasterSlider; // Reference to the UI Slider component
    public Slider BGMSlider; // Reference to the UI Slider component
    public Slider EffectSlider;

    public void SetMasterVolume()
    {
        audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) *20);
    }

    public void SetBGMVolume()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(BGMSlider.value) * 20);
    }

    public void SetEffectVolume()
    {
        audioMixer.SetFloat("Effect", Mathf.Log10(EffectSlider.value) * 20);
    }
}

