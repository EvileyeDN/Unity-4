using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject PowerupPferab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(PowerupPferab, GenerateSpawnPos(), PowerupPferab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(PowerupPferab, GenerateSpawnPos(), PowerupPferab.transform.rotation);
        }
    }
     void SpawnEnemyWave(int EnimestoSpawn)
    {
        for (int i = 0; i < EnimestoSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPos()
    {
        float spawnposX = Random.Range(-spawnRange, spawnRange);
        float spawnposZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnposX, 0, spawnposZ);
        

        return randomPos;
    }
}
