using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nail : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float nailSpeed = 5f;
    [SerializeField] private int dmg = 1;

    private Transform target;

    //gets target from turret script
    public void SetTarget(Transform _target) {
        target = _target;
    }

    //tracks position of target and follows it
    private void FixedUpdate() {
        if(!target) return;

        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * nailSpeed;
    }

    //does damage and deletes itself
    private void OnCollisionEnter2D(Collision2D other) {
        //calls the TakeDamage method from EnemyMovement
        other.gameObject.GetComponent<EnemyMovement>().TakeDamage(dmg);
        Destroy(gameObject);
    }
}
