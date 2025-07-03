#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LinkFontLegacyTexts : MonoBehaviour
{
    // 에디터 메뉴바 상단에 Tools-Fix Legacy Fonts 메뉴 생성
    [MenuItem("Tools/Fix Legacy Fonts")]
    static void FixFont()
    {
        // 연결할 폰트 파일 로드
        Font font = AssetDatabase.LoadAssetAtPath<Font>("Assets/Font/VITRO INSPIRE OTF.otf");

        /*
         * GameObject.FindObjectsOfType<Transform>(true) : 현재 씬에 있는 모든 GameObject들 중에
         * Transform 컴포넌트가 있는 Objects를 가져오는 함수
         * parameter : (includeInactive = true) 비활성화된 오브젝트도 포함
         */
        foreach (Transform transform in GameObject.FindObjectsOfType<Transform>(true))
        {
            Text text = transform.GetComponent<Text>();

            if (!text) continue;

            if (text.font != font)
            {
                text.font = font;   
                // 유니티 에디터에 오브젝트가 변경되었음을 알림
                EditorUtility.SetDirty(text);
                Debug.Log($"Edit font : {text.name}");
            }
        }

        // 필터 "t:Prefab" 타입이 Prefab인 Asset, 탐색경로 
        // return : 탐색경로에서 찾은 Prefab Asset들의 guid를 반환
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