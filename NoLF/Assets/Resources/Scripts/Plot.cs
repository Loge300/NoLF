using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    
    private GameObject tower;
    private Color startColor;

    public Boards boards;
    public Wires wires;
    private int boardsint = 1;
    private int wiresint = 1;

    private void Start() {
        startColor = sr.color;

        GameObject boardObject = GameObject.Find("BoardCount");
        GameObject wireObject = GameObject.Find("WireCount");
        boards = boardObject.GetComponent<Boards>();
        wires = wireObject.GetComponent<Wires>();
    }

    private void OnMouseEnter() {
        sr.color = hoverColor;
    }

    private  void OnMouseExit() {
        sr.color = startColor;
    }

    private void OnMouseDown() {
        if (tower != null) return;
        if(boardsint >= 1 && wiresint >= 1) {
            GameObject towerToBuild = BuildManager.main.GetSelectedTower();
            tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
            boards.increaseBoards(-1);
            wires.increaseWires(-1);
        }
    }
}
