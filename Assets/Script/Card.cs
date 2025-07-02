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
    public GameObject Effect;

    public SpriteRenderer Images;

    public Animator anim;
    public Animator effect_anim;

    public string card = null;

    public bool isFlip = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FlipCard()
    {
        if (InGameManager.Instance.isCanInput && !isFlip)
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
        Invoke("CloseCardHandler", 0.5f);
    }

    void CloseCardHandler()
    {
        Debug.Log("T");
        anim.SetBool("isOpen", false);

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

    public void Open()
    {
        front.SetActive(true);
        back.SetActive(false);
    }

    public void Close()
    {
        front.SetActive(false);
        back.SetActive(true);
    }
    public void EffectOn()
    {
        StartCoroutine(PlayEffectThenDestroy());
    }

    private IEnumerator PlayEffectThenDestroy()
    {
        Effect.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        effect_anim.SetBool("EndOn", true);
        yield return new WaitForSeconds(0.2f);
        Images.enabled = false;
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
