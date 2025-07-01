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
        int imageIdx = Random.Range(0,sprites.Length);
        imageMain.sprite = sprites[imageIdx];
        titleText.text = "Title Text Sample";
        descText.text = "This is description text sample";

        resultView.SetActive(false);
        descView.SetActive(true);
    }
}
