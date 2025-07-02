using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance;

    public GameObject card;
    
    public GameObject resultPanel;
    public GameObject TextImg;

    public Card One;
    public Card Two;

    public Text Timmer;

    public float leftT;

    public bool isCanInput;

    //hidden bool
    public bool what_hid = false;
    //

    List<string> cards = new List<string> 
    { 
        "JDS_Card_Dog", 
        "JDS_Card_Lotte", 
        "JDS_Card_Tichu",
        "KDY_Card_Book", 
        "KDY_Card_Cookie", 
        "KDY_Card_YiSang",
        "KHU_Card_Bombay", 
        "KHU_Card_Pizza", 
        "KHU_Card_Ryzen",
        "LDH_Card_Nursing", 
        "LDH_Card_Maltese", 
        "LDH_Card_PUBG",
        "SMC_Card_DuKi", 
        "SMC_Card_Mickey", 
        "SMC_Card_Mika"};

    List<string> Maincard = new List<string>(24);

    
    public int leftCards = 0;
    public int matchingPairs = 2;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        isCanInput = true;
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("isFirstRun"))
        {
            PlayerPrefs.SetInt("isFirstRun", 1);
            AchievementManager.AddAchievement("1");
        }

        AchievementManager.Instance.CreateUI();

        if (!what_hid)
        {
            //GameStartSetting(12);
            GameStartSetting(1);
        }
        else if (what_hid)
        {
            GameStartSetting(5);
        }

        leftT = 60f;
        GameManager.Instance.GameStart();
    }

    private void Update()
    {
        if(GameManager.state == GameManager.gameState.InPlay)
        {
            leftT -= Time.deltaTime;
            Timmer.text = leftT.ToString("N2");
        }

        if(leftT < 0f)
        {
            Timmer.text = "0.00"; 
            GameManager.state = GameManager.gameState.Result;
            EndGame();
            
        }
    }

    public void Matched()
    {
        isCanInput = false;
        if (One.card == Two.card)
        {

            One.EffectOn();
            Two.EffectOn();

            leftCards -= 2;
            if (leftCards == 0)
            {
                GameManager.state = GameManager.gameState.Result;
                //End Game
                Invoke("EndGame", 0.5f);
            }
            AchievementManager.AddAchievement("2");
            isCanInput = true;
        }
        else
        {
            One.CloseCard();
            Two.CloseCard();
            Invoke("FailEvent", 0.7f);
        }

        card_reset();
    }

    void card_reset()
    {
        One = null;
        Two = null;
    }

    void EndGame()
    {
        resultPanel.SetActive(true);

        ResultUI resultUI = resultPanel.GetComponent<ResultUI>();
        if (resultUI != null)
        {
            resultUI.Init();
        }
        TextImg.transform.SetAsFirstSibling();
        GameManager.Instance.GameClear();
    }

    void FailEvent()
    {
        isCanInput = true;
    }

    void GameStartSetting(int MaxCard)
    {
        cards = cards.OrderBy(x => Random.Range(0f, 15f)).ToList();

        Maincard = cards.Take(MaxCard).ToList();
        for (int j = 0; j < MaxCard; j++)
        {
            Maincard.Add(Maincard[j]);
        }

        //Test disable
        //        Maincard = Maincard.OrderBy(x => Random.Range(0f, 24f)).ToList();
        //

        for (int i = 0; i < Maincard.Count; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.3f - 4.0f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(Maincard[i]);

        }
        //Card Full Count
        leftCards = Maincard.Count;
    }
}
