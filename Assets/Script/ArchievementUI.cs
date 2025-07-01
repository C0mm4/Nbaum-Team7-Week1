using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchievementUI : MonoBehaviour
{
    public bool isArise;
    public Animator animator;
    [SerializeField]
    public Text archievementName;
    public Text archievementDescription;

    public void Awake()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SetNewArchivement(string path)
    {
        animator.SetBool("isArise", true);
        isArise = true;
        var archievement = ArchievementManager.FindArchievementByID(path);


        archievementName.text = archievement.title;
        archievementDescription.text = archievement.description;
        Invoke("EndAriseAnimation", 1.5f);

        PlayerPrefs.SetInt($"A{path}", 1);
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
