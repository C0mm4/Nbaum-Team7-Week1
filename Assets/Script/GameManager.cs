using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance {  get { return instance; } }


    public bool DebugMode;
    private static bool isFirstRun = true;
    public bool isRun;

    public enum gameState
    {
        Title, InPlay, Pause, Result, Menu,
    }
    public static gameState state;

    private void Awake()
    {
        if (instance == null) 
            instance = this;
        state = gameState.Title;
        DontDestroyOnLoad(gameObject);

        Debug.Log(isFirstRun);
        if (isFirstRun)
        {
            if (DebugMode)
            {
                PlayerPrefs.DeleteAll();
            }
            isFirstRun = false;
        }
    }

    private void Update()
    {
        if(state == gameState.Title)
        {
            GameData.titleTime += Time.deltaTime;
            if (GameData.titleTime >= 60f)
            {
                AchievementManager.AddAchievement("6");
            }
        }
    }

    public void GameStart()
    {
        state = gameState.InPlay;
    }

    public void GameClear()
    {
        state = gameState.Result;
        AchievementManager.AddAchievement("4");
    }

    public void GameFail()
    {
        state = gameState.Result;
        AchievementManager.AddAchievement("3");
    }


    public void QuitGame()
    {
#if UNITY_EDITOR
        if (GameManager.Instance.DebugMode)
            PlayerPrefs.DeleteAll();
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnClickAchievementListUI()
    {
        GameObject go = GameObject.Find("Canvas").transform.Find("AchievementListUI").gameObject;
        go.SetActive(true);
    }
}