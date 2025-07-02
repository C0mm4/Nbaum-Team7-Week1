using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonLoader
{
    public TextAsset LoadJsonData(string path)
    {
        try
        {
            TextAsset jsonText = Resources.Load<TextAsset>(path);
            return jsonText;
        }
        catch 
        {
            Debug.LogError($"failed load Json data in {path} file");
            return null;
        }

    }
}
