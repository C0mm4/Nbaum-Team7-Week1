using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescView : MonoBehaviour
{
    public Image imageMain;
    public Text titleText;
    public Text descText;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDescView(Description desc)
    {
        Sprite sprite = ResourceManager.Instance.GetPortrait(desc.img);
        imageMain.sprite = sprite;
        titleText.text = desc.title;
        descText.text = desc.description;
    }
}
