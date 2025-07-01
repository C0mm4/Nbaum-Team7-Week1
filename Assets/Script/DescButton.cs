using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescButton : MonoBehaviour
{
    [SerializeField]
    Image imageMain;
    [SerializeField]
    Text titleText;
    [SerializeField]
    Text descText;
    [SerializeField]
    GameObject descView;
    [SerializeField]
    GameObject resultView;

    Sprite[] sprites;

    private void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("Images/Portrait");
    }

    public void OnClickDesc()
    {
        resultView.SetActive(false);
        descView.SetActive(true);
    }
}
