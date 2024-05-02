using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingHitbox : MonoBehaviour
{

    [SerializeField] private int dmg = 1;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<EnemyMovement>().TakeDamage(dmg);
        }
        Destroy(gameObject);
    }
}

