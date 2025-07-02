#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LinkFontLegacyTexts : MonoBehaviour
{
    [MenuItem("Tools/Fix Legacy Fonts")]
    static void FixFont()
    {
        Font font = AssetDatabase.LoadAssetAtPath<Font>("Assets/Font/VITRO INSPIRE OTF.otf");

        foreach (Transform transform in GameObject.FindObjectsOfType<Transform>(true))
        {
            Text text = transform.GetComponent<Text>();

            if (!text) continue;

            if (text.font != font)
            {
                text.font = font;   
                EditorUtility.SetDirty(text);
                Debug.Log($"Edit font : {text.name}");
            }
        }

        Debug.Log("FixFont Finished.");
    }
}

#endif