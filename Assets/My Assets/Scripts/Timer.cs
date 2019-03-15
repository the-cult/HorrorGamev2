using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timerText;
    public float timer;// 3601.0f;

    void Start()
    {
        timerText.text = " ";
    }

    void Update()
    {

        timer -= Time.deltaTime;
        int seconds = (int)(timer % 60);
        int minutes = (int)(timer / 60) % 60;
        int hours = (int)(timer / 3600) % 24;
        string timerString = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        timerText.text = timerString;
    }
}

