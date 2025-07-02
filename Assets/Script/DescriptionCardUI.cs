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

    public void SetData(Description desc)
    {
        nameTxt.text = desc.title;
        descriptionTxt.text = desc.description;
        img.sprite = Resources.Load<Sprite>(desc.img);

    }
}
