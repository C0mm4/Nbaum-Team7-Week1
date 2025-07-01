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

        
    }



}
