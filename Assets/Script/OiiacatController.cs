using UnityEngine;
using UnityEngine.EventSystems;

public class OiiacatController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Animator catAnimator;


    [Header("Long Press Settings")]
    public float longPressDuration = 1.0f;

    private float pointerDownTimer = 0f;
    private bool isPointerDown = false;

    void OnEnable()
    {
        if (catAnimator != null)
        {
            catAnimator.SetBool("OiiaMoving", false);
        }
    }
    void Update()
    {
        if (isPointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= longPressDuration)
            {
                catAnimator.SetBool("OiiaMoving", true);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("고양이 클릭 성공!");
        isPointerDown = true;
        pointerDownTimer = 0f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        pointerDownTimer = 0f;

        catAnimator.SetBool("OiiaMoving", false);
    }
}
