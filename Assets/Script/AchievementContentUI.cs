using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementContentUI : MonoBehaviour
{
    public Text nameTxt;
    public Text descriptionTxt;
    public GameObject hiding;

    public void SetData(string name, string description, string id)
    {
        if (PlayerPrefs.HasKey($"A{id}"))
        {
            nameTxt.text = name;
            descriptionTxt.text = description;
            hiding.SetActive(false);

        }
        else
        {

            nameTxt.text = "???";
            descriptionTxt.text = "??????????????";
        }


    }
}
