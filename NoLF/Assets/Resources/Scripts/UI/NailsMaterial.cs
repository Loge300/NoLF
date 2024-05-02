using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NailsMaterial : MonoBehaviour
{
    [SerializeField] public TMP_Text nailsText;
    public int nails;
    void Start()
    {
        resetNails();
    }

    public void increaseNails(int increase) {
        nails += increase;
        nailsText.text = nails.ToString();
    }

    public void decreaseNails(int decrease) {
        nails -= decrease;
        nailsText.text = nails.ToString();
    }

    public void resetNails() {
        nails = 0;
        nailsText.text = nails.ToString();
    }

    public int getNails() {
        return nails;
    }
}
