using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{

    public GameObject Credit;
    public GameObject backButton;

    public void OnClickBackBtn()
    {   // Load the main menu scene (assuming it's named "MainMenuScene")
        Credit.SetActive(false);
        backButton.SetActive(false);
    }
}
