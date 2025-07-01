using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    public static GameData Instance {  get { return instance; } }

    public static int winStreak;
    public static int loseStreak;
    public static int matchCombo;
    public static int missCombo;
    public static float lastMatchT;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastMatchT >= 10f)
        {
            // Card Shake Event Activate
        }
    }
}
