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
            Debug.Log($"�������� �߰�: {archievement.title} - {archievement.description}");
        }
        else
        {
            Debug.Log("�ش� ID�� ���������� ã�� �� �����ϴ�.");
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
