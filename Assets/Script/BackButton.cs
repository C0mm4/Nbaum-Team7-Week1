using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public static CreditButton Instance; // Singleton instance

    public GameObject Credit;
    public GameObject backButton;

    public AudioSource TrapCard; // Reference to the AudioSource component
    public AudioSource bgmusic; // Reference to the AudioSource component

    public void OnClickBackBtn()
    {   // Load the main menu scene (assuming it's named "MainMenuScene")
        Credit.SetActive(false);
        backButton.SetActive(false);
    }


  

    public void trapCardStop()
    {
        if (Instance == null)
            TrapCard = GetComponent<AudioSource>();

        else
            TrapCard = Instance.GetComponent<AudioSource>();

        TrapCard.Pause();
        bgmusic.Play();
    }



}
