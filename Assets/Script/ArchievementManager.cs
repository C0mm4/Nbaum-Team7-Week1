using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    private static AchievementManager instance;
    public static AchievementManager Instance {  get { return instance; } }

    public static Queue<string> newAchivements = new Queue<string>();
    public AchievementUI achievementUI;

    public static GameData gameData;

    public GameObject achievementUIPrefs;


    private static List<Achievement> achievements;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);


        if (achievementUI == null)
        {
            CreateUI();
        }

        gameData = new GameData();
        gameData.Init();

        LoadArchivements();

    }

    public void OnClickTitle()
    {
        gameData.titleClickCnt++;
        if(gameData.titleClickCnt >= 5)
        {
            newAchivements.Enqueue("5");
        }
        else
        {
            RectTransform rect = GameObject.Find("GameTitle").GetComponent<RectTransform>();
            rect.localScale += new Vector3(0.01f, 0.01f, 0);
        }
    }

    public static void OnFlipEvent()
    {

    }

    public static void OnMatchEvent()
    {
        AddArchievement("2");
    }

    public static void OnMatchFailEvent()
    {

    }

    public static void OnEndEvent()
    {

    }

    public static void OnClearEvent()
    {
        AddArchievement("4");
    }

    public static void OnFailEvent()
    {

        AddArchievement("3");
    }

    public void Update()
    {
        if(newAchivements.Count > 0)
        {
            Debug.Log(newAchivements.Peek());
            Debug.Log(achievementUI);
            if(achievementUI == null)
            {
                CreateUI();
            }
            else if (!achievementUI.isArise)
            {
                Debug.Log("achievementUI isn't Arise");
                Debug.Log("playerPrefs hasn't key");
                achievementUI.SetNewArchivement(newAchivements.Peek());
                newAchivements.Dequeue();
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            newAchivements.Enqueue("7");
        }
    }

    public void LoadArchivements()
    {
        TextAsset jsonText = Resources.Load<TextAsset>("Data/Archievement");
        AchievementList archievementList = JsonUtility.FromJson<AchievementList>(jsonText.text);
        achievements = archievementList.list;

    }

    public static Achievement FindArchievementByID(string id)
    {
        return achievements.FirstOrDefault(x => x.id == id);
    }

    public static void AddArchievement(string id)
    {
        if (!PlayerPrefs.HasKey($"A{id}"))
        {
            PlayerPrefs.SetInt($"A{id}", 1);
            newAchivements.Enqueue(id);
        }
    }


    public void CreateUI()
    {
        GameObject canvas = GameObject.Find("Canvas");
        achievementUI = Instantiate(achievementUIPrefs, canvas.transform).GetComponent<AchievementUI>(); ;
    }
}
