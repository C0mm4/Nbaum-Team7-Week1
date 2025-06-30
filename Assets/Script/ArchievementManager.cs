using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchievementManager : MonoBehaviour
{
    private static ArchievementManager instance;
    public static ArchievementManager Instance {  get { return instance; } }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
        action += OnFlipEvent;
    }

    public static void OnFlipEvent()
    {
        Debug.Log("A");
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
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            action?.Invoke();
        }
    }

}
