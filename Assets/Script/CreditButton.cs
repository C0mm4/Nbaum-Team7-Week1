using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditButton : MonoBehaviour
{
    public GameObject Credit; // Reference to the Credit button GameObject
    public GameObject backButton; // Reference to the Back button GameObject

    public AudioSource TrapCard; // Reference to the AudioSource component
    public AudioSource bgmusic;


    // Start is called before the first frame update
    public void OnClickCreditBtn()
    {   // Load the game scene (assuming it's named "GameScene")
        Credit.SetActive(true);
        backButton.SetActive(true);

        trapCardPlay();
     
    }

    public void trapCardPlay()
    {
        SoundControl.Instance.PauseBGM();
        SoundControl.Instance.PlayBGM(ResourceManager.Instance.LoadAudioClip("Sounds/BGM/TrapCard"));
    }

  
}
