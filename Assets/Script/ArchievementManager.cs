using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArchievementManager : MonoBehaviour
{
    private static ArchievementManager instance;
    public static ArchievementManager Instance {  get { return instance; } }

    public static Queue<string> newArchivements = new Queue<string>();
    public ArchievementUI archievementUI;

    public int qc;
    public static GameData gameData;

    
    private static List<Archievement> archievements;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
        action += OnMatchEvent;



        gameData = new GameData();
        gameData.Init();

        LoadArchivements();

    }

    public static void OnFlipEvent()
    {
        newArchivements.Enqueue("2");
    }

    public static void OnMatchEvent()
    {
        var archieve = FindArchievementByID("1");

        newArchivements.Enqueue(archieve.id);
    }

    public static void OnMatchFailEvent()
    {

    }

    public static void OnEndEvent()
    {

    }

    public static void OnClearEvent()
    {

    }

    public static void OnFailEvent()
    {

    }

    event Action action;

    public void Update()
    {
        qc = newArchivements.Count;
        if(newArchivements.Count > 0)
        {
            if (!archievementUI.isArise)
            {
                if (!PlayerPrefs.HasKey($"A{newArchivements.Peek()}"))
                {
                    archievementUI.SetNewArchivement(newArchivements.Peek());
                    newArchivements.Dequeue();
                }
                else
                {
                    newArchivements.Dequeue();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            action?.Invoke();
        }
    }

    public void LoadArchivements()
    {
        TextAsset jsonText = Resources.Load<TextAsset>("Data/Archievement");
        ArchievementList archievementList = JsonUtility.FromJson<ArchievementList>(jsonText.text);
        archievements = archievementList.list;

        Debug.Log(archievements.Count);
        foreach (Archievement archievement in archievements) 
        {
            Debug.Log(archievement.id);
        }
    }

    public static Archievement FindArchievementByID(string id)
    {
        return archievements.FirstOrDefault(x => x.id == id);
    }
}
