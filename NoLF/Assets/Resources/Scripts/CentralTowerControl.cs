using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CentralTowerControl : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private Score score;
    [SerializeField] private EnemySpawner spawner;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Collision Detected with Tower");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Damage Dealt to Tower");
            health = health - 1;
            //if the enemies health reaches zero it spawns a whatever game object is connected to the scrap variable and then is destroyed.  
            if (health <= 0)
            {
                PlayerPrefs.SetInt("lastscore", score.score);
                PlayerPrefs.SetInt("lastwave", spawner.waveCount);
                SceneManager.LoadScene("GameOver");
            }
        }
    }

}
