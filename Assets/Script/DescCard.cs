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

    public void SetData(Description desc)
    {
        nameTxt.text = $"[{desc.player}/È¿°ú]";
        titleTxt.text = desc.title;
        descTxt.text = desc.description;
        img.sprite = Resources.Load<Sprite>(desc.img);
    }
}
