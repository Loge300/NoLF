using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject shadowBlack;
    public GameObject shadowRed;
    // When highlighted with mouse.
    public void Start()
    {
        shadowBlack.SetActive(true);
        shadowRed.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        shadowBlack.SetActive(false);
        shadowRed.SetActive(true);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        shadowBlack.SetActive(true);
        shadowRed.SetActive(false);
    }
}
