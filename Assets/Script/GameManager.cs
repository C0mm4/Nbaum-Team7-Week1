using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance {  get { return instance; } }


    public bool DebugMode;
    private static bool isFirstRun = true;
    public bool isRun;


    public static GameData gameData;

    public GameObject titleEndMenu;

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
        else
        {
            Destroy(gameObject);
        }
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

        OnLoadTitle();
    }

    public void Update()
    {
        if(state == gameState.Title)
        {
            if(Time.time - titleEndMenu.GetComponent<GameEndUI>().EndT >= 1f)
                if (Input.GetKeyUp(KeyCode.Escape)) 
                {
                    titleEndMenu.SetActive(true);
                }

        }
    }


    public void GameStart()
    {
        state = gameState.Loading;
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

    public void GoToTitle()
    {
        SceneManager.sceneLoaded += OnLoadTitleCallback;
        SceneManager.LoadScene("StartScene");
    }

    public void OnLoadTitle()
    {
        GameObject go = FindGameObject("StartBtn");
        Button btn = go.GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(OnClickGameStartBtn);
        }

        go = FindGameObject("LevelSelectBack");
        btn = go.GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(OnClickBackInLevelSelectUI);
        }
        
        go = FindGameObject("AchievementButton");
        btn = go.GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(OnClickAchievementListUI);
        }

        titleEndMenu = FindGameObject("GameEndUI");

        stageLevel = 0;
        SceneManager.sceneLoaded -= OnLoadTitleCallback;
    }

    public void OnLoadTitleCallback(Scene scene, LoadSceneMode mode)
    {
        OnLoadTitle();
        SoundControl.Instance.OnLoadTitle();
        AchievementManager.Instance.OnLoadTitle();
    }


    public GameObject FindGameObject(string name)
    {
        Transform[] allTransforms = GameObject.FindObjectsOfType<Transform>(true);
        foreach (Transform t in allTransforms)
        {
            if (t.name == name)
            {
                GameObject go = t.gameObject;
                Debug.Log("찾음: " + go.name);
                return go;
            }
        }
        return null;
    }
}