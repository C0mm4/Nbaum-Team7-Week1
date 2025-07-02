using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescView : MonoBehaviour
{
    [SerializeField]
    private Image imageMain;
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Text descText;

    public void SetDescView(Description desc)
    {
        Sprite sprite = ResourceManager.Instance.GetPortrait(desc.img);
        imageMain.sprite = sprite;
        titleText.text = desc.title;
        descText.text = desc.description;
    }
}
