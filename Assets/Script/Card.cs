using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            isFlip = true;
            anim.SetBool("isOpen", true);
            front.SetActive(true);
            back.SetActive(false);
           

            if (InGameManager.Instance.leftCards > 0)
            {
                if (InGameManager.Instance.One == null)
                {   
                    InGameManager.Instance.One = this;
                }
                else
                {
                    InGameManager.Instance.Two = this;
                    InGameManager.Instance.Matched();
                    

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

    }

    public void Setting(string image)
    {
        card = image;
        Images.sprite = Resources.Load<Sprite>("Images/Portrait/"+image);
        
    }
}
