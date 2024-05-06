using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinHit : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private int dmg = 1;

    //does damage and deletes itself
    private void OnCollisionEnter2D(Collision2D other) {
        //calls the TakeDamage method from EnemyMovement
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<EnemyMovement>().TakeDamage(dmg);
        }
        Destroy(gameObject);
    }
}
