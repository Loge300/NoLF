using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed
    public GameObject attackHitboxPrefab; // Reference to the attack hitbox prefab
    public Transform attackPoint; // Point where the attack hitbox will be spawned
    public float attackCooldown = 1f; // Time between attacks
    private Rigidbody2D rb;
    private float nextAttackTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from the user
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize the vector to ensure constant speed in all directions
        movement.Normalize();

        // Move the character
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);

        // Attack input handling
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextAttackTime)
        {
            // attackPoint = transform.position;
            Attack();
            nextAttackTime = Time.time + 1f / attackCooldown;
        }
    }

    void Attack()
    {
        // Spawn the attack hitbox in front of the character
        Instantiate(attackHitboxPrefab, attackPoint.position, attackPoint.rotation);
    }
}
