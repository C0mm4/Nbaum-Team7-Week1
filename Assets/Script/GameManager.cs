using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
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
    }

    public void GameFail()
    {
        isPlaying = false;
        resultText.text = "시간 초과!";
        ShowResultPanel();
    }

    private void ShowResultPanel()
    {
        resultPanel.SetActive(true);
        inGamePanel.SetActive(false);
    }

    public bool isMatched()
    {
        Debug.Log("매칭 확인 중...");
        return true;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}