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

    public static Queue<string> newAchievements = new Queue<string>();
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

        LoadAchivements();

    }

    public void OnClickTitle()
    {
        gameData.titleClickCnt++;
        if(gameData.titleClickCnt >= 5)
        {
            AddAchievement("5");
        }
        else
        {
            RectTransform rect = GameObject.Find("GameTitle").GetComponent<RectTransform>();
            rect.localScale += new Vector3(0.01f, 0.01f, 0);
        }
    }

    public static void OnStartEvent()
    {
        AddAchievement("1");
        if(GameManager.stageLevel == 3)
        {
            AddAchievement("8");
        }
    }

    public static void OnFlipEvent()
    {

    }

    public static void OnMatchEvent()
    {
        AddAchievement("2");
    }

    public static void OnMatchFailEvent()
    {

    }

    public static void OnEndEvent()
    {

    }

    public static void OnClearEvent()
    {
        AddAchievement("4");
        if (GameManager.stageLevel == 3)
        {
            AddAchievement("9");
            GameData.hiddenClearCnt++;
            if (GameData.hiddenClearCnt >= 5)
            {
                AddAchievement("10");
            }
        }
        GameData.clearCnt++;
    }

    public static void OnFailEvent()
    {

        AddAchievement("3");
    }

    public void Update()
    {
        if(newAchievements.Count > 0)
        {
            Debug.Log(newAchievements.Peek());
            Debug.Log(achievementUI);
            if(achievementUI == null)
            {
                CreateUI();
            }
            else if (!achievementUI.isArise)
            {
                achievementUI.SetNewArchivement(newAchievements.Peek());
                newAchievements.Dequeue();
                
            }
        }
        if(GameManager.state == GameManager.gameState.Title)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                AddAchievement("7");
            }
            GameData.titleTime += Time.deltaTime;
            if(GameData.titleTime >= 300f)
            {
                AddAchievement("6");
            }
        }
    }

    public void LoadAchivements()
    {
        //        TextAsset jsonText = ResourceManager.Instance.jsonLoader.LoadJsonData("Data/Archievement");
        TextAsset jsonText = Resources.Load<TextAsset>("Data/Archievement");
        AchievementList archievementList = JsonUtility.FromJson<AchievementList>(jsonText.text);
        achievements = archievementList.list;
        Debug.Log(achievements.Count);
    }

    public Achievement FindAchievementByID(string id)
    {
        return achievements.FirstOrDefault(x => x.id == id);
    }

    public static void AddAchievement(string id)
    {
        if (!PlayerPrefs.HasKey($"A{id}"))
        {
            PlayerPrefs.SetInt($"A{id}", 1);
            newAchievements.Enqueue(id);
        }
    }


    public void CreateUI()
    {
        GameObject canvas = GameObject.Find("Canvas");
        achievementUI = Instantiate(achievementUIPrefs, canvas.transform).GetComponent<AchievementUI>(); ;
    }

    public static List<Achievement> GetAchievementList() 
    {
        Debug.Log(achievements.Count);
        return achievements;
    }

}
