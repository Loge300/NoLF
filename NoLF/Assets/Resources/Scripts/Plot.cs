using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    private CraftButton button;

    private GameObject tower;
    private Color startColor;

    private void Start() {
        startColor = sr.color;
        GameObject buttonObject = GameObject.Find("craftButton");
        button = buttonObject.GetComponent<CraftButton>();
    }

    private void OnMouseEnter() {
        sr.color = hoverColor;
    }

    private  void OnMouseExit() {
        sr.color = startColor;
    }

    private void OnMouseDown() {
        if (tower != null) return;
        if (button.towerHeld != -1) {
            GameObject towerToBuild = BuildManager.main.GetSelectedTower();
            tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
            button.towerHeld = -1;
            button.disableAllPlots();
        }
    }
}
