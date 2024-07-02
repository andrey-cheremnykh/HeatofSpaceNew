using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Vector3 minSpawnPos, maxSpawnPos;
    [SerializeField] int desiredEnemyCount = 10;
    EnemyHealth[] enemies;
    PlayerHealth player;
    int enemyCount = 0;
    private void Update()
    {
        player = FindObjectOfType<PlayerHealth>();
        SpawnEnemies();
    }
    void SpawnEnemies()
    {
        if (player == null) return;
        bool isEnemyCountAboveOrHigherThanDesired = false;
        enemies = FindObjectsOfType<EnemyHealth>();
        enemyCount = enemies.Length;
        if (enemyCount >= desiredEnemyCount) isEnemyCountAboveOrHigherThanDesired = true;
        if (isEnemyCountAboveOrHigherThanDesired == true) return;

        int IndexofEnemyPrefabToSpawn = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyPrefabToSpawn = enemyPrefabs[IndexofEnemyPrefabToSpawn];
        float SpawnPosX = Random.Range(minSpawnPos.x, maxSpawnPos.x);
        float SpawnPosY = Random.Range(minSpawnPos.y, maxSpawnPos.y);
        float SpawnPosZ = Random.Range(minSpawnPos.z, maxSpawnPos.z);
        Vector3 spawnPos = new Vector3(SpawnPosX, SpawnPosY, SpawnPosZ);
        Instantiate(enemyPrefabToSpawn,spawnPos,Quaternion.identity);
    }
}
