using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager
 : MonoBehaviour
{
    GroundSpawn groundSpawn;
    void Start()
    {
        groundSpawn = GameObject.FindObjectOfType<GroundSpawn>();
        SpawnObstacle();
        SpawnCoin();
    }

    private void OnTriggerExit(Collider other) 
    {
        groundSpawn.SpawnGround();
        Destroy(gameObject,4);
    }

    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2,5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject coinPrefab;

    void SpawnCoin()
    {
        float spawnChance = Random.Range(0f, 1f);

        if (spawnChance < 0.3f)
        {
            int coinSpawnIndex = Random.Range(5, 8);
            Transform spawnPoint = transform.GetChild(coinSpawnIndex).transform;

            Quaternion rotation = Quaternion.Euler(0, 0, 45);
        

            Instantiate(coinPrefab, spawnPoint.position, rotation, transform);
        }
    }

}
