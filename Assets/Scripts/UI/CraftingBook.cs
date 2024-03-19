using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingBook : MonoBehaviour
{
    [SerializeField] private string[] towerNames;
    [SerializeField] private string[] towerDPS;
    [SerializeField] private string[] towerRanges;
    [SerializeField] private int[] towerIngredientOne;
    [SerializeField] private int[] towerIngredientTwo;
    [SerializeField] private int[] towerIngredientOneNum;
    [SerializeField] private int[] towerIngredientTwoNum;
    [SerializeField] private GameObject[] ingredientSprites;
    [SerializeField] private GameObject cantCraft;
    [SerializeField] private GameObject[] towerPreviews;
    private int onScreenPos = 119;
    private int offScreenPos = 113;
    private int direction;
    private int targetPos;
    private float speed;
    void Start()
    {
        transform.position = new Vector3(325, offScreenPos, 0);
        slide(onScreenPos, 1);
    }

    void Update() {
        if (direction == 1) {
            if (transform.position.y < targetPos) {
                speed *= 1.02f;
                transform.position += new Vector3(0, speed, 0);
            }
        } else {
            if (transform.position.y > targetPos) {
                speed *= 1.02f;
                transform.position -= new Vector3(0, speed, 0);
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
}
