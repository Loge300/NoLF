using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed
    private Rigidbody2D rb;
    [SerializeField] private CraftingBook book;
    Animator animator_B;
    SpriteRenderer sprite_renderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator_B = gameObject.GetComponent<Animator>();
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get input from the user
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        //Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize the vector to ensure constant speed in all directions
        //movement.Normalize();

        // Move the character
        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        animator_B.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        if (horizontalInput < 0)
        {
            sprite_renderer.flipX = true;
        }
        else if  (horizontalInput > 0)
        {
            sprite_renderer.flipX = false;
        }

        animator_B.SetBool("IsHitting", false);

        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("Swing");
            animator_B.SetBool("IsHitting", true);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("PLAYER COLLISION ENTER");
        if (other.gameObject.CompareTag("CentralTower")) {
            //Debug.Log("PLAYER TOWER COLLISION ENTER");
            book.slideIn();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //Debug.Log("PLAYER COLLISION EXIT");
        if (other.gameObject.CompareTag("CentralTower")) {
            //Debug.Log("PLAYER TOWER COLLISION EXIT");
            book.slideOut();
        }
    }
}
