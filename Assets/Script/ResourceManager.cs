using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager instance;
    public static ResourceManager Instance { get { return instance; } }

    public JsonLoader jsonLoader = new JsonLoader();

    Dictionary<string, Sprite> portraits = new Dictionary<string, Sprite>();
    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    List<Description> descriptions = new();
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        LoadDescription();

        List<Description> temp = new List<Description>(descriptions);

        foreach (Description description in temp)
        {
            Sprite sprite = Resources.Load<Sprite>(description.img);
     
            if (!sprite)
            {
                descriptions.Remove(description);
            }
            else
            {
                portraits.Add(description.img, sprite);
            }
        }

    }

    public void LoadDescription()
    {
        TextAsset jsonText = jsonLoader.LoadJsonData("Data/Description");
        var descriptionList = JsonUtility.FromJson<DescriptionList>(jsonText.text);

        descriptions = descriptionList.list;

    }

    public Sprite GetPortrait(string path)
    {
        if (!portraits.ContainsKey(path))
        {
            Sprite sprite = Resources.Load<Sprite>(path);
            if (sprite)
            {
                portraits.Add(path, sprite);
            }
        }

        return portraits[path];
    }

    public Description GetRandomDescription()
    {
        int randomIndex = Random.Range(0, portraits.Count);
        Description desc = descriptions[randomIndex];

        return desc;
    }

    public List<Description> GetDescriptions()
    {
        return descriptions;
    }

    public AudioClip LoadAudioClip(string path)
    {
        if (!audioClips.ContainsKey(path))
        {
            AudioClip audioClip = Resources.Load<AudioClip>(path);

            if(audioClip)
            {
                audioClips.Add(path, audioClip);
            }
        }

        return audioClips[path];
    }
}
