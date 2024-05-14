using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 14;
    private bool isWaveActive = true;
    private bool stopSpawning = false;
    [SerializeField] private Vector2 _targetPosition;
    [SerializeField] private Timer timer;

    public GameObject[] enemies;

    public int waveCount;  //Needs to be connected to the UI
    private int enemyCount = 1;
    private float nextWaveTime = 1.0f;
    //private float spawnRate = 1.0f;
    private float timeBetweenWaves = 5.0f;

    


    // Start is called before the first frame update
    void Start()
    {
        //Sets the spawner center to center
        _targetPosition = Vector2.zero;

        StartCoroutine(spawnAWave());
    }



    IEnumerator spawnAWave() 
    {
        while (isWaveActive == true && stopSpawning == false) 
        {
            int totalTime = 6;
            timer.setTime(totalTime);
            timer.setWave(waveCount);
            //setting of spawn position and selection of which enemy will be spawned
            Vector2 spawnPos = _targetPosition;
            
            int randomEnemy = Random.Range(0, enemies.Length);
            isWaveActive = false;

            yield return new WaitForSeconds(nextWaveTime);
            //spawns enemies one at a time based on the spawn rate but waits to do so unitl the wave timer is complete
            for (int i = 0; i < enemyCount; i++) 
            {
                //ActivateWaveText();
                
                //wave
                spawnPos = Random.insideUnitCircle.normalized * spawnRadius;
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
                //yield return new WaitForSeconds(spawnRate);
            }

            //Makes the next wave harder and resets other variables needed.  
            enemyCount += 1;
            yield return new WaitForSeconds(timeBetweenWaves);
            waveCount += 1;
            Debug.Log("wave complete: " + waveCount); //You can replace this line with the stuff for the UI updating
            isWaveActive = true;
        }

        
    }
}
