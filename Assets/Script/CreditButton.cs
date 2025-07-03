using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditButton : MonoBehaviour
{

    public static CreditButton Instance; // Singleton instance

    public GameObject Credit; // Reference to the Credit button GameObject
    public GameObject backButton; // Reference to the Back button GameObject

    public AudioSource TrapCard; // Reference to the AudioSource component
    public AudioSource bgmusic;


    // Start is called before the first frame update
    public void OnClickCreditBtn()
    {   // Load the game scene (assuming it's named "GameScene")
        Credit.SetActive(true);
        backButton.SetActive(true);
     
    }

    public void trapCardPlay()
    { 
    if (Instance == null)
        TrapCard = GetComponent<AudioSource>();

    else         
            TrapCard = Instance.GetComponent<AudioSource>();

        bgmusic.Pause();
        TrapCard.Play(); 
    }

  
}
