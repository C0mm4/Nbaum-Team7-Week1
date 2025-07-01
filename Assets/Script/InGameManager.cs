using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance;

    public GameObject card;

    public Card One;
    public Card Two;

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
    public int matchingPairs = 0;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        if (!PlayerPrefs.HasKey("isFirstRun"))
        {
            PlayerPrefs.SetInt("isFirstRun", 1);
            ArchievementManager.AddArchievement("1");
        }

        ArchievementManager.Instance.CreateUI();
    }

    void Start()
    {
        cards = cards.OrderBy(x => Random.Range(0f, 15f)).ToList();

        Maincard = cards.Take(12).ToList();
        for(int j = 0; j < 12; j++)
        {
            Maincard.Add(Maincard[j]);
        }

        for (int i = 0; i < Maincard.Count; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.3f - 4.0f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(Maincard[i]);    

        }
        //카드 총 카운트
        matchingPairs = Maincard.Count;


    }

    public void Matched()
    {
        if (One.card == Two.card)
        {
            One.DestroyCard();
            Two.DestroyCard();
            matchingPairs -= 2;
            leftCards = 0;

            if (matchingPairs == 0)
            {
                //게임종료
                Invoke("EndGame", 0.5f);
            }
        }
        else
        {
            One.CloseCard();
            Two.CloseCard();
            leftCards = 0;
        }

        card_reset();
    }

    void card_reset()
    {
        One.isFlip = false;
        Two.isFlip = false;
        One = null;
        Two = null;
    }

    void EndGame()
    {
        Time.timeScale = 0.0f;
    }

}
