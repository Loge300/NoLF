using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scores;
    void Start()
    {
        if (!PlayerPrefs.HasKey("highscore")) {
            PlayerPrefs.SetInt("highscore", 0);
        }
        if (!PlayerPrefs.HasKey("bestwave")) {
            PlayerPrefs.SetInt("bestwave", 0);
        }
        scores.text = "High Score: " + PlayerPrefs.GetInt("highscore") + "<br>" + "Best Wave: " + PlayerPrefs.GetInt("bestwave");
    }
}
