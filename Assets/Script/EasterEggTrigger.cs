using UnityEngine;
using UnityEngine.EventSystems;

public class EasterEggTrigger : MonoBehaviour, IPointerClickHandler
{
    public GameObject oiiaCatObject;


    private int clicksNeeded = 5;

    private int currentClicks = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        currentClicks++;

        Debug.Log("Credit panel clicked! Current count: " + currentClicks);

        if (currentClicks == clicksNeeded)
        {
            if (oiiaCatObject != null && !oiiaCatObject.activeSelf)
            {
                oiiaCatObject.SetActive(true);
                oiiaCatObject.transform.SetAsLastSibling();
                Debug.Log("Easter Egg Activated! Oiia cat appears!");

                this.enabled = false;
            }
        }
    }
}
