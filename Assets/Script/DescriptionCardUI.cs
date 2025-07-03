using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionCardUI : MonoBehaviour
{

    public Text nameTxt;
    public Text descriptionTxt;
    public Text playerTxt;
    public Image img;

    public GameObject hiding;

    public void SetData(Description desc)
    {
        nameTxt.text = desc.title;
        descriptionTxt.text = desc.description;
        img.sprite = ResourceManager.Instance.GetPortrait(desc.img);

        playerTxt.text = $"[{desc.player}/È¿°ú]";


        if (PlayerPrefs.HasKey($"C{desc.id}"))
        {
            hiding.SetActive(false);

        }
        else
        {

            hiding.SetActive(true);
        }
    }
}
