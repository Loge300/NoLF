using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wires : MonoBehaviour
{
    [SerializeField] public TMP_Text wireText;
    public int wires;
    void Start()
    {
        resetWires();
    }

    public void increaseWires(int increase) {
        wires += increase;
        wireText.text = wires.ToString();
    }
    public void decreaseWires(int decrease) {
        wires -= decrease;
        wireText.text = wires.ToString();
    }

    public void resetWires() {
        wires = 0;
        wireText.text = wires.ToString();
    }

    public int getWires() {
        return wires;
    }
}
