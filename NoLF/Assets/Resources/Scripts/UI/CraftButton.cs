using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftButton : MonoBehaviour
{
    [SerializeField] private Sprite cantCraftButton;
    [SerializeField] private Sprite canCraftButton;
    [SerializeField] private CraftingBook book;
    [SerializeField] private Wires wires;
    [SerializeField] private Boards boards;
    [SerializeField] private Plastic plastic;
    [SerializeField] private NailsMaterial nails;
    [SerializeField] GameObject plots;
    private bool canCraft;
    public int towerHeld = -1;
    void Start()
    {
        towerHeld = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (book.currentPage == 0) {
            if(nails.getNails() >= 4 && plastic.getPlastic() >= 3) {
                canCraft = true;
                GetComponent<SpriteRenderer>().sprite = canCraftButton;
            } else {
                canCraft = false;
                GetComponent<SpriteRenderer>().sprite = cantCraftButton;
            }
        }
        else if (book.currentPage == 1) {
            if(boards.getBoards() >= 4 && wires.getWires() >= 3) {
                canCraft = true;
                GetComponent<SpriteRenderer>().sprite = canCraftButton;
            } else {
                canCraft = false;
                GetComponent<SpriteRenderer>().sprite = cantCraftButton;
            }
        }
    }

    private void OnMouseDown() {
        Debug.Log("Craft Button Clicked");
        if (canCraft) {
            plots.SetActive(true);
            if (book.currentPage == 0) {
                book.slideOut();
                nails.decreaseNails(4);
                plastic.decreasePlastic(3);
                towerHeld = 0;
            } else if (book.currentPage == 1) {
                book.slideOut();
                boards.decreaseBoards(4);
                wires.decreaseWires(3);
                towerHeld = 1;
            }
        }
    }

    public void disableAllPlots() {
        plots.SetActive(false);
    }
}
