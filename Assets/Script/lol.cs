using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lol : MonoBehaviour
{
    public Image image;
    public Dropdown dropdown;
    public Text auK;

    public float R;
    public float G;
    public float B;

    int state = 0;

    // Start is called before the first frame update
    void Start()
    {
        R = Random.Range(0f, 1f);
        G = Random.Range(0f, 1f);
        B = Random.Range(0f, 1f);

        dropdown.onValueChanged.AddListener(OnChangeLevelDrowndown);
        auK.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 0:
                R += Time.deltaTime;
                if(R >= 1f)
                {
                    R = 1;
                    state = 1;
                }
                break;
            case 1:
                G += Time.deltaTime;
                if(G >= 1f)
                {
                    G = 1;
                    state = 2;
                }
                break;
            case 2:
                B += Time.deltaTime;
                if(B >= 1f)
                {
                    B = 1f;
                    state = 3;
                }
                break;
            case 3:
                R -= Time.deltaTime;
                if (R < 0)
                {
                    R = 0;
                    state = 4;
                }
                break;
            case 4:
                G -= Time.deltaTime;
                if (G < 0)
                {
                    G = 0;
                    state = 5;
                }
                break;
            case 5:
                B -= Time.deltaTime;
                if (B < 0)
                {
                    B = 0;
                    state = 0;
                }
                break;
        }

        image.color = new Color(R, G, B, 0.7f);
    }

    void OnChangeLevelDrowndown(int level)
    {
        GameManager.Instance.stageLevel = level;
        if(level == 2)
        {
            auK.gameObject.SetActive(true);
        }
        else
        {
            auK.gameObject.SetActive(false);
        }
    }
}
