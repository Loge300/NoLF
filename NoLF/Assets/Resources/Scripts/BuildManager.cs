using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] private CraftButton button;

    private void Awake() {
        main = this;
    }

    public GameObject GetSelectedTower() {
        return towerPrefabs[button.towerHeld];
    }
}
