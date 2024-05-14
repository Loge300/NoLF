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
        InvokeRepeating("TickDown", 1f, 1f);
        //waveText.text = "Wave<br>" + wave;
    }

    public void setTime(int secs) {
        CancelInvoke();
        seconds = secs;
        if (seconds >= 10) {
            timerText.text = "0:" + seconds;
        } else {
            timerText.text = "0:0" + seconds;
        }
        InvokeRepeating("TickDown", 1f, 1f);
    }

    public void setWave(int wave) {
        waveText.text = "Wave<br>" + wave;
    }

    void TickDown() {
        seconds--;
        if (seconds < 0) {
            seconds = 0;
        }
        if (seconds >= 10) {
            timerText.text = "0:" + seconds;
        } else {
            timerText.text = "0:0" + seconds;
        }
    }

    
}
