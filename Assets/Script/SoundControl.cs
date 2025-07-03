using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public static SoundControl instance;
    public static SoundControl Instance {  get { return instance; } }

    [SerializeField] private AudioClip FlipEffects; // Array to hold sound effects
    [SerializeField] private AudioClip matchEffects; // Array to hold sound effects

    [SerializeField] private AudioSource masterInstance;
    [SerializeField] private AudioSource BGMInstance;
    [SerializeField] private AudioSource EffectInstance;

    private AudioSource audioSource; // Reference to the AudioSource component


    private void Awake()
    {
        if(instance == null)
            instance = this;

        audioSource = this.GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject

        DontDestroyOnLoad(gameObject);
    }

    public void PlayBGM(AudioClip clip)
    {
        BGMInstance.clip = clip;
        BGMInstance.Play();
    }

    public void PauseBGM()
    {
        BGMInstance.Pause();
    }

    public void PlayEffect(AudioClip clip)
    {
        EffectInstance.PlayOneShot(clip);
    }
}
