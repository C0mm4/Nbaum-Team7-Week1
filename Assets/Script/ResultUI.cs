using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    public static List<Description> descriptions = new();
    public Image img;
    public Text nameTxt;
    public Text descriptionTxt;

    // Start is called before the first frame update
    void Start()
    {
        LoadDescription();
        int rand = 1;
        SetDescription(rand.ToString());
    }

    public void LoadDescription()
    {
        TextAsset jsonText = Resources.Load<TextAsset>("Data/Description");
        var descriptionList = JsonUtility.FromJson<DescriptionList>(jsonText.text);
        
        descriptions = descriptionList.list;
        Debug.Log(descriptions.Count);

    }
    public static Description FindDescriptionByID(string id)
    {
        return descriptions.FirstOrDefault(x => x.id == id);
    }

    public void SetDescription(string id)
    {
        var desc = FindDescriptionByID(id);
        img.sprite = Resources.Load<Sprite>(desc.img);
        nameTxt.text = desc.title;
        descriptionTxt.text = desc.description;
    }
}
