using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    public static List<Description> descriptions;

    // Start is called before the first frame update
    void Start()
    {
        LoadDescription();
    }

    public void LoadDescription()
    {
        TextAsset jsonText = Resources.Load<TextAsset>("Data/Description");
        var descriptionList = JsonUtility.FromJson<DescriptionList>(jsonText.text);
        descriptions = descriptionList.list;

    }
    public static Description FindArchievementByID(string id)
    {
        return descriptions.FirstOrDefault(x => x.id == id);
    }
}
