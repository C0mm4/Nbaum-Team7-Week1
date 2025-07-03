#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LinkFontLegacyTexts : MonoBehaviour
{
    // ������ �޴��� ��ܿ� Tools-Fix Legacy Fonts �޴� ����
    [MenuItem("Tools/Fix Legacy Fonts")]
    static void FixFont()
    {
        // ������ ��Ʈ ���� �ε�
        Font font = AssetDatabase.LoadAssetAtPath<Font>("Assets/Font/VITRO INSPIRE OTF.otf");

        /*
         * GameObject.FindObjectsOfType<Transform>(true) : ���� ���� �ִ� ��� GameObject�� �߿�
         * Transform ������Ʈ�� �ִ� Objects�� �������� �Լ�
         * parameter : (includeInactive = true) ��Ȱ��ȭ�� ������Ʈ�� ����
         */
        foreach (Transform transform in GameObject.FindObjectsOfType<Transform>(true))
        {
            Text text = transform.GetComponent<Text>();

            if (!text) continue;

            if (text.font != font)
            {
                text.font = font;   
                // ����Ƽ �����Ϳ� ������Ʈ�� ����Ǿ����� �˸�
                EditorUtility.SetDirty(text);
                Debug.Log($"Edit font : {text.name}");
            }
        }

        // ���� "t:Prefab" Ÿ���� Prefab�� Asset, Ž����� 
        // return : Ž����ο��� ã�� Prefab Asset���� guid�� ��ȯ
        string[] guids = AssetDatabase.FindAssets("t:Prefab", new[] { "Assets/Prefeb" });

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);

            Text[] texts = prefab.GetComponentsInChildren<Text>(true);
            bool changed = false;

            foreach (Text text in texts)
            {
                if (!text) continue;

                if (text.font != font)
                {
                    text.font = font;
                    changed = true;
                }
            }

            if (changed)
            {
                EditorUtility.SetDirty(prefab);
                Debug.Log($"Fixed fonts in : {path}");
            }

            AssetDatabase.SaveAssets();
        }

        Debug.Log("FixFont Finished.");
    }
}

#endif