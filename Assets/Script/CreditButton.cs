using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditButton : MonoBehaviour
{

    public GameObject Credit; // Reference to the Credit button GameObject
    public GameObject backButton; // Reference to the Back button GameObject

    // Start is called before the first frame update
    public void OnClickCreditBtn()
    {   // Load the game scene (assuming it's named "GameScene")
        Credit.SetActive(true);
        backButton.SetActive(true);
    }
}
