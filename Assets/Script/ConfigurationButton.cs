using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigurationButton : MonoBehaviour
{

    public AudioClip clip;
    public AudioSource audioSource;

    public GameObject Configuration; // Reference to the configuration panel GameObject
    public GameObject Master_Slider;
    public GameObject BGM_Slider;
    public GameObject Effect_Slider;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // Ensure the game is running at normal speed
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
    }

    public void OnClickConfigurationButton()
    { 
      audioSource.PlayOneShot(clip); // Play the sound effect when the button is clicked
      Configuration.SetActive(true); // Show the configuration panel
    }

    
}
