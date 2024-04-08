using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    //Variables in order.  Speed of enemy, where the enemy is going, the health of the enemy, the game object that will drop when the enemy is killed
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector2 _targetPosition;
    [SerializeField] private int health = 1;
    [SerializeField] private GameObject scrap;
    public Score score;

    private void Start()
    {
        GameObject scoreObject = GameObject.Find("ScoreDisplay");
        score = scoreObject.GetComponent<Score>();
        //Sets the target of the enemy to the center of the scene
        _targetPosition = Vector2.zero;
    }

    /*I dont know why this code is here but it might be useful later.  Keep it for now then remove it for the final project if not needed.  
     * private void MoveTo(Vector2 position)
    {
        _targetPosition = position;
    }*/

    private void Update() {
        //moves the enemy toward the center every frame at the enemies speed variable
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
                
        // Use this code for testing decreasing helth related code
    }

    public void TakeDamage(int dmg) {
        health -= dmg;
        if(health <= 0) {
            Instantiate(scrap, transform.position, transform.rotation);
            score.increaseScore(10);
            GameObject.Destroy(gameObject);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D enemy)
    {
        //if the enemy collides with anything with the hitbox tag it takes damage
        if(enemy.CompareTag("Hitbox")) 
        {
            Debug.Log("Damage Dealt");
            health = health - 1;
            //if the enemies health reaches zero it spawns a whatever game object is connected to the scrap variable and then is destroyed.  
            if (health <= 0)
            {
                Instantiate(scrap, transform.position, transform.rotation);
                score.increaseScore(10);
                GameObject.Destroy(gameObject);
            }
        }
    }*/
}
