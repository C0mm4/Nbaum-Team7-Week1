using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchievementUI : MonoBehaviour
{
    public bool isArise;
    public Animator animator;
    public Text archievementName;
    public Text archievementDescription;

    public void Awake()
    {
    }

    public void SetNewArchivement(string path)
    {
        animator.SetBool("isArise", true);
        isArise = true;
        var archievement = ArchievementManager.FindArchievementByID(path);
        if (archievement != null)
        {
            Debug.Log($"도전과제 발견: {archievement.title} - {archievement.description}");
        }
        else
        {
            Debug.Log("해당 ID의 도전과제를 찾을 수 없습니다.");
        }

        archievementName.text = archievement.title;
        archievementDescription.text = archievement.description;
        Invoke("EndAriseAnimation", 1.5f);


    }

    public void EndAriseAnimation()
    {
        animator.SetBool("isArise", false);
        Invoke("EndFlag", 0.5f);
    }

    private void EndFlag()
    {
        isArise = false;
    }
}
