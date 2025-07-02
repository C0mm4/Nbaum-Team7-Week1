using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationButton : MonoBehaviour
{

    public AudioClip clip;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // Ensure the game is running at normal speed
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
    }

    public void OnClickConfigurationButton()
    { 
      audioSource.PlayOneShot(clip); // Play the sound effect when the button is clicked
    }

    
}
