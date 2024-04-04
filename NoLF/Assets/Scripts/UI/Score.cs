using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreText;
    public int score;
    void Start()
    {
        resetScore();
    }

    public void increaseScore(int increase) {
        score += increase;
        scoreText.text = "Score: " + score;
    }

    public void resetScore() {
        score = 0;
        scoreText.text = "Score: 0";
    }
}
