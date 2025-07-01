using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchievementManager : MonoBehaviour
{
    private static ArchievementManager instance;
    public static ArchievementManager Instance {  get { return instance; } }

    public static Queue<int> newArchivements = new Queue<int>();
    public ArchievementUI archievementUI;

    public int qc;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
        action += OnFlipEvent;

        newArchivements.Enqueue(0);
        newArchivements.Enqueue(0);
        newArchivements.Enqueue(0);
    }

    public static void OnFlipEvent()
    {
        newArchivements.Enqueue(0);
    }

    public static void OnMatchEvent()
    {

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
                archievementUI.SetNewArchivement();
                newArchivements.Dequeue();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            action?.Invoke();
        }
    }

}
