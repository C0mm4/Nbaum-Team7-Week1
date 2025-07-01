using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance {  get { return instance; } }

    public GameObject titlePanel;
    public GameObject inGamePanel;
    public GameObject resultPanel;

    public Button startButton;
    public Button retryButton;
    public Button quitButton;

    public Text timeText;
    public Text resultText;

    public float gameTime = 30f;

    private float currentTime;
    private bool isPlaying;

    public bool DebugMode;
    private void Awake()
    {
        if (instance == null) 
            instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SetupUI();
    }

    private void Update()
    {
        if (isPlaying)
        {
            currentTime -= Time.deltaTime;
            timeText.text = Mathf.CeilToInt(currentTime).ToString();

            if (currentTime <= 0)
            {
                GameFail();
            }
        }
    }

    private void SetupUI()
    {
        titlePanel.SetActive(true);
        inGamePanel.SetActive(false);
        resultPanel.SetActive(false);

        startButton.onClick.AddListener(GameStart);
        retryButton.onClick.AddListener(GameStart);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void GameStart()
    {
        titlePanel.SetActive(false);
        inGamePanel.SetActive(true);
        resultPanel.SetActive(false);

        currentTime = gameTime;
        isPlaying = true;
    }

    public void GameClear()
    {
        isPlaying = false;
        resultText.text = "게임 성공!";
        ShowResultPanel();
        AchievementManager.OnClearEvent();
    }

    public void GameFail()
    {
        isPlaying = false;
        resultText.text = "시간 초과!";
        ShowResultPanel();

        AchievementManager.OnFailEvent();
    }

    private void ShowResultPanel()
    {
        resultPanel.SetActive(true);
        inGamePanel.SetActive(false);
    }

    public bool isMatched()
    {
        Debug.Log("매칭 확인 중...");

        AchievementManager.OnMatchEvent();
        return true;

        // Add Fail Case
        AchievementManager.OnMatchFailEvent();
        return false;
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
}