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

    public GameObject[] enemies;

    private int waveCount;
    private int enemyCount;
    private float nextWaveTime = 1.0f;
    private float spawnRate = 1.0f;
    private float timeBetweenWaves = 5.0f;

    


    // Start is called before the first frame update
    void Start()
    {
        //Sets the spawner center to center
        _targetPosition = Vector2.zero;

        StartCoroutine(spawnAWave());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator spawnAWave() 
    {
        while (isWaveActive == true && stopSpawning == false) 
        {
            //setting of spawn position and selection of which enemy will be spawned
            Vector2 spawnPos = _targetPosition;
            
            int randomEnemy = Random.Range(0, enemies.Length);
            isWaveActive = false;

            //spawns enemies one at a time based on the spawn rate but waits to do so unitl the wave timer is complete
            for (int i = 0; i < enemyCount; i++) 
            {
                //ActivateWaveText();
                yield return new WaitForSeconds(nextWaveTime);
                //wave
                spawnPos = Random.insideUnitCircle.normalized * spawnRadius;
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(spawnRate);
            }

            //Makes the next wave harder and resets other variables needed.  
            spawnRate -= 0.2f;
            enemyCount += 1;
            yield return new WaitForSeconds(timeBetweenWaves);
            waveCount += 1;
            Debug.Log("wave complete: " + waveCount);
            isWaveActive = true;
        }

        
    }
}
