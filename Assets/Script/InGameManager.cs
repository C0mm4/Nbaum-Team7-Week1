using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance;

    public GameObject card;

    List<string> cards = new List<string> 
    { "BA_mika.png", "dog.jpg", "dog1.jpg", "DOYUL_BOOK.jpg", "DOYUL_Cookie.jpg",
    "DOYUL_YISANG.png","duki.jpg", "KHU_Bombay.png", "KHU_Drumset.png", "KHU_Pizza.png",
    "KHU_Ryzen775.png", "team.png","BA_mika.png", "dog.jpg", "dog1.jpg", "DOYUL_BOOK.jpg", "DOYUL_Cookie.jpg",
    "DOYUL_YISANG.png","duki.jpg", "KHU_Bombay.png", "KHU_Drumset.png", "KHU_Pizza.png",
    "KHU_Ryzen775.png", "team.png" };

    public string leftCards = null;
    public int matchingPairs = 0;
    

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

        //GameManager.Instance.cardCount = arr.Length;
    }



}
