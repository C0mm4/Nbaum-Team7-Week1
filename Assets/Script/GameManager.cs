using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance {  get { return instance; } }


    public bool DebugMode;
    private static bool isFirstRun = true;
    public bool isRun;


    public static GameData gameData;

    public enum gameState
    {
        Title, InPlay, Pause, Result, Menu, Loading,
    }
    public static gameState state;

    public static int stageLevel;

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
        gameData = new GameData();
        gameData.Init();

        
    }


    public void GameStart()
    {
        state = gameState.InPlay;
        GameData.startGame();
    }

    public void GameClear()
    {
        state = gameState.Result;
        AchievementManager.OnClearEvent();
    }

    public void GameFail()
    {
        state = gameState.Result;
        AchievementManager.OnFailEvent();
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

    public void OnClickGameStartBtn()
    {
        GameObject go = GameObject.Find("Canvas").transform.Find("LevelSelectUI").gameObject;
        go.SetActive(true);
    }

    public void OnClickBackInLevelSelectUI()
    {
        GameObject go = GameObject.Find("Canvas").transform.Find("LevelSelectUI").gameObject;
        go.SetActive(false);
    }
}