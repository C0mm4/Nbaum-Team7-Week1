using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGameButton : MonoBehaviour
{
    public GameObject Configuration; // Reference to the configuration panel GameObject
    public GameObject Master_Slider;
    public GameObject BGM_Slider;
    public GameObject Effect_Slider;
    public void OnClickBackGameButton()
    {
        GameManager.state = GameManager.gameState.InPlay;
        Configuration.SetActive(false); // Show the configuration panel
    }
}
