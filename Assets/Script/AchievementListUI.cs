using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementListUI : MonoBehaviour
{
    public GameObject contentPrefs;
    public GameObject contentParent;
    public Button backBtn;
    public Scrollbar scroll;

    public List<GameObject> contentViews;
    public List<Button> viewSelectBtns;

    public void OnEnable()
    {
        GameManager.state = GameManager.gameState.Menu;
        contentParent.transform.position = new Vector2(contentParent.transform.position.x, 0);
        scroll.value = 0;
        backBtn.onClick.AddListener(OnClickButtonEvent);
        SetAchievements();
    }

    public void OnDisable()
    {
        GameManager.state = GameManager.gameState.Title;

        foreach(Transform item in contentParent.transform)
        {
            if(item.transform != contentParent.transform)
                Destroy(item.gameObject);
        }

        backBtn.onClick.RemoveAllListeners();
    }

    public void Start()
    {
        for (int i = 0; i < viewSelectBtns.Count; i++) 
        {
            int index = i;
            viewSelectBtns[i].onClick.AddListener(() =>
            {
                for(int j = 0; j < contentViews.Count; j++)
                {
                    contentViews[j].SetActive(false);
                }
                Debug.Log(index);
                contentViews[index].SetActive(true);
            });
        }
    }

    public void SetAchievements()
    {
        var achievements = AchievementManager.GetAchievementList();
        Debug.Log(achievements.Count);
        foreach (var achievement in achievements)
        {
            GameObject go = Instantiate(contentPrefs, contentParent.transform);
            AchievementContentUI achievementContentUI = go.GetComponent<AchievementContentUI>();
            achievementContentUI.SetData(achievement.title, achievement.description, achievement.id);
        }

    }

    public void OnClickButtonEvent()
    {
        gameObject.SetActive(false);
    }
}
