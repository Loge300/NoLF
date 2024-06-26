using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int dmg = 1;
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject attackSwing;
    public Transform attackSwingTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canFire = true;
        timeBetweenFiring = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(!canFire) 
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring) 
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire) 
        {
            canFire = false;
            Instantiate(attackSwing, attackSwingTransform.position, Quaternion.identity);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        //calls the TakeDamage method from EnemyMovement
        other.gameObject.GetComponent<EnemyMovement>().TakeDamage(dmg);
    }
}
