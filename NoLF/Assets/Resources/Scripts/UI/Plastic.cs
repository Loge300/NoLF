using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Plastic : MonoBehaviour
{
    [SerializeField] public TMP_Text plasticText;
    public int plastic;
    void Start()
    {
        resetPlastic();
    }

    public void increasePlastic(int increase) {
        plastic += increase;
        plasticText.text = plastic.ToString();
    }

    public void decreasePlastic(int decrease) {
        plastic -= decrease;
        plasticText.text = plastic.ToString();
    }

    public void resetPlastic() {
        plastic = 0;
        plasticText.text = plastic.ToString();
    }

    public int getPlastic() {
        return plastic;
    }
}
