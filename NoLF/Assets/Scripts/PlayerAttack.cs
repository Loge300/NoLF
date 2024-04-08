using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] public Transform attackTransform;
    [SerializeField] private int dmg = 1;
    private float attackRange = 1.5f;
    private LayerMask attackableLayer;
    private float nextAttackTime;
    private float attackCooldown = 1f;

    private RaycastHit2D[] hits;

    // Update is called once per frame
    void Update()
    {
        // Attack input handling
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextAttackTime)
        {
            // attackPoint = transform.position;
            Attack();
            nextAttackTime = Time.time + 1f / attackCooldown;
        }
    }

    void Attack() {
        //hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);
    }
}
