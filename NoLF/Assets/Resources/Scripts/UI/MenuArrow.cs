using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuArrow : MonoBehaviour
{
    [SerializeField] private CraftingBook book;
    
    private void OnMouseDown() {
        book.turnPage();
    }
}
