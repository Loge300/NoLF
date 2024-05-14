using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{

    [SerializeField] public TMP_Text timerText;
    [SerializeField] public TMP_Text waveText;
    int seconds;
    int minutes;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreaseTime", 1f, 1f);
        //waveText.text = "Wave<br>" + wave;
    }

    public void setTime(int secs) {
        seconds = secs % 60;
        minutes = secs / 60;
        CancelInvoke();
        InvokeRepeating("IncreaseTime", 1f, 1f);
    }

    public void setWave(int wave) {
        waveText.text = "Wave<br>" + wave;
    }

    void IncreaseTime() {
        if (seconds <= 0) {
            if (minutes != 0) {
                minutes--;
                seconds = 59;
            }
            seconds = 0;
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
