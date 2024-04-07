using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed
    private Rigidbody2D rb;
    [SerializeField] private CraftingBook book;

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
        //Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize the vector to ensure constant speed in all directions
        //movement.Normalize();

        // Move the character
        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);
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
