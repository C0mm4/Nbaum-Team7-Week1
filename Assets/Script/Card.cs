using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Card : MonoBehaviour
{
    public GameObject front;
    public GameObject back;

    public SpriteRenderer Images;

    public Animator anim;

    public string card = null;

    public bool isFlip = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FlipCard()
    {
        if (!isFlip)
        {
            Debug.Log("A");
            isFlip = true;
            anim.SetBool("isOpen", true);
            Invoke("OpenCardHanlder", 0.5f);
           

            if (InGameManager.Instance.leftCards > 0)
            {
                if (InGameManager.Instance.One == null)
                {   
                    InGameManager.Instance.One = this;
                }
                else
                {
                    Invoke("Match", 0.6f);


                }
            }

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
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);

        isFlip = false;
    }

    void OpenCardHanlder()
    {
        front.SetActive(true);
        back.SetActive(false);
    }

    public void Setting(string image)
    {
        card = image;
        Images.sprite = Resources.Load<Sprite>("Images/Portrait/"+image);
        
    }

    public void Flip()
    {

        front.SetActive(true);
        back.SetActive(false);
    }

    public void Match()
    {
        InGameManager.Instance.Two = this;
        InGameManager.Instance.Matched();
    }
}
