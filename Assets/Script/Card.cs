using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Sprite Image;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    public int cardData = 0;

    public bool isFlip = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FlipCard()
    {
        anim.SetBool("isArise", true);
        front.SetActive(true);
        back.SetActive(false);
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
}
