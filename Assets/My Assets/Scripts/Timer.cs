using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timerText, gameIntroText;
    public float timer;// 3601.0f;
    float gameIntroCoundown = 0f;
    public static bool gameTimerStarted = false;

    void Start()
    {
        timerText.text = " ";
        gameIntroText.text = "Claire has been reported missing. Find her and bring her home safely!";
        gameIntroText.enabled = true;
    }

    void Update()
    {
        if (gameTimerStarted)
        {
            timer -= Time.deltaTime;
            int seconds = (int)(timer % 60);
            int minutes = (int)(timer / 60) % 60;
            int hours = (int)(timer / 3600) % 24;
            string timerString = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            timerText.text = timerString;
        }


        gameIntroCoundown += Time.deltaTime;
        if (gameIntroCoundown > 7f)
        {
            gameIntroText.enabled = false;
        }
    }
}

