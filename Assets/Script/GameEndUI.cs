using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndUI : MonoBehaviour
{
    float activeT;
    public float EndT = -1;

    public void OnEnable()
    {
        AchievementManager.AddAchievement("7");
        GameManager.state = GameManager.gameState.Menu;
        activeT = Time.time;
    }

    public void OnDisable()
    {
        GameManager.state = GameManager.gameState.Title;
        EndT = Time.time;
    }

    public void Update()
    {
        if(Time.time - activeT >= 1f)
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                OnClickFalse();
            }
    }

    public void OnClickFalse()
    {
        gameObject.SetActive(false);
    }

    public void OnClickYes()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
