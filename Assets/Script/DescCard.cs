using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescCard : MonoBehaviour
{
    public Text titleTxt;
    public Text nameTxt;
    public Text descTxt;
    public Image img;

    public GameObject hiding;

    public void SetData(Description desc)
    {
        nameTxt.text = $"[{desc.player}/ȿ��]";
        titleTxt.text = desc.title;
        descTxt.text = desc.description;
        img.sprite = Resources.Load<Sprite>(desc.img);


        if (PlayerPrefs.HasKey($"A{desc.id}"))
        {
            hiding.SetActive(false);

        }
        else
        {

            hiding.SetActive(true);
        }

    }
}
