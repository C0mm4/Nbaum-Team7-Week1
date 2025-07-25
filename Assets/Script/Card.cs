using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

public class Card : MonoBehaviour
{
    public GameObject front;
    public GameObject back;
    public GameObject Effect;

    public SpriteRenderer Images;
    public SpriteRenderer Frames;

    public Animator anim;
    public Animator effect_anim;

    public string card = null;

    public bool isFlip = false;

    Vector2 move = new Vector2(1,1);

    float speed = 4.0f;

    bool hidden_firstCheck = true;

    float Check_TIme = 0;
    float Hidden_Card_Speed = 4.0f;

    public AudioClip flipSound;

    // Start is called before the first frame update
    void Start()
    {

        if (GameManager.stageLevel == 3)
        {
            Debug.Log("Stage Level : "
    + GameManager.stageLevel);
            move = Random.insideUnitCircle.normalized;
            anim.SetBool("Hidden", true);        
        }
    }

    void Update()
    {
        Check_TIme += Time.deltaTime;
        if (GameManager.stageLevel == 3 && GameManager.state == GameManager.gameState.InPlay)
        {
            if (hidden_firstCheck)
            {
                Invoke("MoveCard", 3.0f);
                hidden_firstCheck = false;

            }
            else
            { 
                if(Check_TIme > 4.0f)
                {
                    Hidden_Card_Speed = Random.Range(2f, 10f);
                    Check_TIme = 0.0f;
                }
                MoveCard();
                transform.Rotate(0, 0, 10);
            }
        }
    }
    public void FlipCard()
    {
        if (InGameManager.Instance.isCanInput && !isFlip)
        {
            //Debug.Log("A");
            SoundControl.Instance.PlayEffect(flipSound);
            GameData.flipCount++;
            isFlip = true;
            anim.SetBool("isOpen", true);
            Invoke("OpenCardHanlder", 0.5f);

            AchievementManager.OnFlipEvent();

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
                speed++;
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
        //Debug.Log("T");
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
        Images.sprite = ResourceManager.Instance.GetPortrait("Images/Portrait/" + image);
        
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
        Frames.enabled = false;
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    public void MoveCard(float card_speed)
    {
        Vector2 pos = transform.position;
        Vector2 nextPos = pos + move.normalized * card_speed * Time.deltaTime;

        if (nextPos.x < -2.57f || nextPos.x > 2.57f)
        {
            move = Vector2.Reflect(move, Vector2.right);
        }
        if (nextPos.y < -4.4f || nextPos.y > 2.8f)
        {
            move = Vector2.Reflect(move, Vector2.up);
        }

        transform.position += (Vector3)(move.normalized * card_speed * Time.deltaTime);
    }

    public void MoveCard()
    {
        MoveCard(Hidden_Card_Speed);
    }
}
