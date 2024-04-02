using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7, time = 1.5f;
    [SerializeField] private Vector2 _targetPosition;

    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the spawner center to center
        _targetPosition = Vector2.zero;

        StartCoroutine(SpawnAnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator SpawnAnEnemy() 
    {
        Vector2 spawnPos = _targetPosition;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
}
