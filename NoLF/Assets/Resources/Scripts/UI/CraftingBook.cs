using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftingBook : MonoBehaviour
{
    [SerializeField] private string[] towerNames;
    [SerializeField] private string[] towerDPS;
    [SerializeField] private string[] towerRanges;
    [SerializeField] private GameObject[] ingredientSprites;
    [SerializeField] private GameObject[] towerPreviews;
    private int onScreenPos = 119;
    private int offScreenPos = 113;
    private int direction;
    private int targetPos;
    private float speed;
    public int currentPage = 0;
    [SerializeField] private Wires wires;
    [SerializeField] private Boards boards;
    [SerializeField] private Plastic plastic;
    [SerializeField] private NailsMaterial nails;
    [SerializeField] public TMP_Text craftItemCount1;
    [SerializeField] public TMP_Text craftItemCount2;
    [SerializeField] public TMP_Text towerName;
    [SerializeField] public TMP_Text towerStats;
    private Color goodColor = new Color (0.02658505f, 0.6078432f, 0.0f);
    private Color badColor = new Color (0.6075471f, 0.0f, 0.0f);
    void Start()
    {
        transform.position = new Vector3(325, offScreenPos, 0);
        setPage(0);
        //slide(onScreenPos, 1);
    }

    void Update() {
        if (direction == 1) {
            if (transform.position.y < targetPos) {
                speed *= 1.1f;
                transform.position += new Vector3(0, speed, 0);
            }
        } else {
            if (transform.position.y > targetPos) {
                speed *= 1.1f;
                transform.position -= new Vector3(0, speed, 0);
            }
        }
        //Spikpistol: 3 Plastic, 4 Nails
        if (currentPage == 0) {
            craftItemCount1.text = plastic.getPlastic() + "/3";
            if (plastic.getPlastic() >= 3) {
                craftItemCount1.color = goodColor;
            } else {
                craftItemCount1.color = badColor;
            }
            craftItemCount2.text = nails.getNails() + "/4";
            if (nails.getNails() >= 4) {
                craftItemCount2.color = goodColor;
            } else {
                craftItemCount2.color = badColor;
            }
        //Hammerstol: 4 Boards, 3 Wires
        } else if (currentPage == 1) {
            craftItemCount1.text = boards.getBoards() + "/4";
            if (boards.getBoards() >= 4) {
                craftItemCount1.color = goodColor;
            } else {
                craftItemCount1.color = badColor;
            }
            craftItemCount2.text = wires.getWires() + "/3";
            if (wires.getWires() >= 3) {
                craftItemCount2.color = goodColor;
            } else {
                craftItemCount2.color = badColor;
            }
        }
    }

    // Update is called once per frame
    void slide(int targetPosParam, int directionParam) {
        if (transform.position.y > onScreenPos) {
            transform.position = new Vector3(325, onScreenPos, 0);
        }
        if (transform.position.y < offScreenPos) {
            transform.position = new Vector3(325, offScreenPos, 0);
        }
        speed = 0.05f;
        direction = directionParam;
        targetPos = targetPosParam;
    }

    public void slideIn() {
        slide(onScreenPos, 1);
    }

    public void slideOut() {
        slide(offScreenPos, -1);
    }

    public void turnPage() {
        if (currentPage == 0) {
            setPage(1);
        } else {
            setPage(0);
        }
    }

    public void setPage(int targetPage) {
        towerName.text = towerNames[targetPage].ToString();
        towerStats.text = "DPS: " + towerDPS[targetPage]
                + "<br>" + "Range: " + towerRanges[targetPage];
        if (targetPage == 0) {
            towerPreviews[1].SetActive(false);
            towerPreviews[0].SetActive(true);
            ingredientSprites[0].SetActive(false); //Board
            ingredientSprites[3].SetActive(false); //Wire
            ingredientSprites[1].SetActive(true); //Plastic
            ingredientSprites[2].SetActive(true); //Nail
            currentPage = 0;
        } else if (targetPage == 1) {
            towerPreviews[0].SetActive(false);
            towerPreviews[1].SetActive(true);
            ingredientSprites[0].SetActive(true); //Board
            ingredientSprites[3].SetActive(true); //Wire
            ingredientSprites[1].SetActive(false); //Plastic
            ingredientSprites[2].SetActive(false); //Nail
            currentPage = 1;
        }
    }
}
