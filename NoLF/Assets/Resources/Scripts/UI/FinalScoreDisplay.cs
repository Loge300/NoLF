using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private GameObject scoreRecord;
    [SerializeField] private GameObject waveRecord;
    void Start()
    {
        int lastScore = PlayerPrefs.GetInt("lastscore");
        int lastWave = PlayerPrefs.GetInt("lastwave");
        if (lastScore > PlayerPrefs.GetInt("highscore")) {
            PlayerPrefs.SetInt("highscore", lastScore);
            scoreRecord.SetActive(true);
        }
        if (lastWave > PlayerPrefs.GetInt("bestwave")) {
            PlayerPrefs.SetInt("bestwave", lastWave);
            waveRecord.SetActive(true);
        }
        scoreText.text = "Score: " + lastScore;
        waveText.text = "Wave: " + lastWave;
    }

}
