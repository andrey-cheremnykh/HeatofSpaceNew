using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Vector3 minSpawnPos, maxSpawnPos;
    [SerializeField] int desiredEnemyCount = 10;
    EnemyHealth[] enemies;
    int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
    }
    void SpawnEnemies()
    {
        bool isEnemyCountAboveOrHigherThanDesired = false;
        enemies = FindObjectsOfType<EnemyHealth>();
        enemyCount = enemies.Length;
        if (enemyCount >= desiredEnemyCount) isEnemyCountAboveOrHigherThanDesired = true;
        if (isEnemyCountAboveOrHigherThanDesired == true) return;

        int IndexofEnemyPrefabToSpawn = Random.Range(0, enemyPrefabs.Length /*- 1*/);
        GameObject enemyPrefabToSpawn = enemyPrefabs[IndexofEnemyPrefabToSpawn];
        float SpawnPosX = Random.Range(minSpawnPos.x, maxSpawnPos.x);
        float SpawnPosY = Random.Range(minSpawnPos.y, maxSpawnPos.y);
        float SpawnPosZ = Random.Range(minSpawnPos.z, maxSpawnPos.z);
        Vector3 spawnPos = new Vector3(SpawnPosX, SpawnPosY, SpawnPosZ);
        Instantiate(enemyPrefabToSpawn,spawnPos,Quaternion.identity);
    }
}
