using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boards : MonoBehaviour
{
    [SerializeField] public TMP_Text boardText;
    public int boards;
    void Start()
    {
        resetBoards();
    }

    public void increaseBoards(int increase) {
        boards += increase;
        boardText.text = boards.ToString();
    }
    public void decreaseBoards(int decrease) {
        boards -= decrease;
        boardText.text = boards.ToString();
    }

    public void resetBoards() {
        boards = 0;
        boardText.text = boards.ToString();
    }

    public int getBoards() {
        return boards;
    }
}
