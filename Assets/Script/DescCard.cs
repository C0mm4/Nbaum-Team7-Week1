using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescCard : MonoBehaviour
{
    public Text titleTxt;
    public Text descTxt;

    public void SetData(Description desc)
    {
        titleTxt.text = desc.title;
        descTxt.text = desc.description;
    }
}
