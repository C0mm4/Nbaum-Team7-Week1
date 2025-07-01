using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    //public SpriteRenderer Image;

    public GameObject front;
    public GameObject back;

    public Image Image;

    public Animator anim;

    public string cardData = null;

    public bool isFlip = false;

    string a;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FlipCard()
    {
        if (!isFlip)
        {
            isFlip = true;
            anim.SetBool("isArise", true);
            front.SetActive(true);
            back.SetActive(false);
            
            /*
            if (InGameManager.Instance.leftCards == null)
            {
                InGameManager.Instance.leftCards = cardData;
            }
            else
            {
                if (InGameManager.Instance.leftCards == cardData)
                {
                    InGameManager.Instance.matchingPairs++;
                }
            }
            */
            //if()
        }
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardHandler", 0.3f);
    }

    void DestroyCardHandler()
    {
        Destroy(gameObject);        
    }

    public void CloseCard()
    {
        Invoke("CloseCardHandler", 0.3f);
    }

    void CloseCardHandler()
    {
        anim.SetBool("isArise", false);
        front.SetActive(false);
        back.SetActive(true);

    }

    public void Setting(string image)
    {
        Debug.Log(a);
        Image = GetComponent<Image>();
        front.GetComponent<SpriteRenderer> = 
        front.GetComponent<Image>() = Resources.Load(image);
       // Image = Resources.Load<Image>(image);
        cardData = image;

    }
}
