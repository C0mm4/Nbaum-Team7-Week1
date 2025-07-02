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

        foreach (var text in GameObject.FindObjectsOfType<Text>(true))
        {
            if (!text.font)
            {
                text.font = font;   
                EditorUtility.SetDirty(text);
                Debug.Log($"폰트 수정: {text.name}");
            }
        }

        Debug.Log("폰트 일괄 수정 완료");
    }
}

#endif