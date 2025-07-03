using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    [SerializeField] private AudioClip FlipEffects; // Array to hold sound effects
    [SerializeField] private AudioClip matchEffects; // Array to hold sound effects


    private AudioSource audioSource; // Reference to the AudioSource component


    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
    }

 
}
