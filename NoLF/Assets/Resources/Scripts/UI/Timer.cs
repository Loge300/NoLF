using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{

    [SerializeField] public TMP_Text timerText;
    int seconds;
    int minutes;
    // Start is called before the first frame update
    void Start()
    {
        resetTime();
        InvokeRepeating("IncreaseTime", 1f, 1f);
    }

    void resetTime() {
        minutes = 5;
        seconds = 0;
    }

    void IncreaseTime() {
        if (seconds == 0) {
            if (minutes == 0) {
                resetTime();
            } else {
                minutes--;
                seconds = 59;
            }
        } else {
            seconds--;
        }
        if (seconds >= 10) {
            timerText.text = minutes + ":" + seconds;
        } else {
            timerText.text = minutes + ":0" + seconds;
        }
    }

    
}
