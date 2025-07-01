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
    { "BA_mika", "dog", "dog1", "DOYUL_BOOK", "DOYUL_Cookie",
    "DOYUL_YISANG","duki", "KHU_Bombay", "KHU_Drumset", "KHU_Pizza",
    "KHU_Ryzen775", "team","BA_mika", "dog", "dog1", "DOYUL_BOOK", "DOYUL_Cookie",
    "DOYUL_YISANG","duki", "KHU_Bombay", "KHU_Drumset", "KHU_Pizza",
    "KHU_Ryzen775", "team" };

    public int leftCards = 0;
    public int matchingPairs = 0;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    void Start()
    {

        cards = cards.OrderBy(x => Random.Range(0f, 24f)).ToList();


        for (int i = 0; i < cards.Count; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.3f - 4.0f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(cards[i]);    

        }
        //카드 총 카운트
        matchingPairs = cards.Count;


    }

    public void Matched()
    {
        //Debug.Log($"First : {One.Images}, Seconde : {Two.Images}");
        if (One.card == Two.card)
        {
            One.DestroyCard();
            Two.DestroyCard();
            matchingPairs -= 2;
            leftCards = 0;

            if (matchingPairs == 0)
            {
                //게임종료
                Time.timeScale = 0.0f;
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
}
