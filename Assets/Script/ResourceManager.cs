using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager instance;
    public static ResourceManager Instance { get { return instance; } }
    Dictionary<string, Sprite> portraits = new Dictionary<string, Sprite>();
    public List<Description> descriptions = new();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        LoadDescription();
        Debug.Log(descriptions.Count);

        foreach (Description description in descriptions)
        {
            Sprite sprite = Resources.Load<Sprite>(description.img);
            if (sprite != null)
            {
                portraits.Add(description.img, sprite);
            }
        }

        Debug.Log(portraits.Count);

    }

    public void LoadDescription()
    {
        TextAsset jsonText = Resources.Load<TextAsset>("Data/Description");
        var descriptionList = JsonUtility.FromJson<DescriptionList>(jsonText.text);

        descriptions = descriptionList.list;

    }

    public Sprite GetPortrait(string path)
    {
        return portraits[path];
    }

    public Description GetRandomDescription()
    {
        int randomIndex = Random.Range(0, 3);
        Description desc = descriptions[randomIndex];

        return desc;
    }
}
