using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickStartBtn()
     {   // Load the game scene (assuming it's named "GameScene")
        SceneManager.LoadScene("GameScene");
    }
}
