using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    GroundSpawn groundSpawn;

    // Define prefabs on ground
    public GameObject obstaclePrefab1;
    public GameObject obstaclePrefab2;
    public GameObject obstaclePrefab3;
    public GameObject emptyPrefab;
    public GameObject coinPrefab;
    public GameObject sizeGainCube;
    private Transform player;
    private GameOver gameOver;
    private GameTimeManager timer;
    private static bool spawnEmptyToggle = true;

    void Start()
    {   
        gameOver = FindObjectOfType<GameOver>();
        timer = FindObjectOfType<GameTimeManager>();
        if (!gameOver.gameover)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }

            groundSpawn = GameObject.FindObjectOfType<GroundSpawn>();
            SpawnObstacle();
            CollectableSpawn();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject newGround = groundSpawn.SpawnGround();
        Destroy(gameObject, 4);
    }

    void SpawnObstacle()
    {
        if (timer.timer < 50) // Level 1: Always spawn obstacles
        {
            int obstacleSpawnIndex = Random.Range(2, 5);
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
            GameObject obj = Instantiate(obstaclePrefab1, spawnPoint.position, Quaternion.identity, transform);
        }
        else if (timer.timer >= 50) // Level 2: Alternate between empty and obstacle-filled grounds
        {
            if (spawnEmptyToggle)
            {
                // Spawn the empty prefab
                GameObject obj = Instantiate(emptyPrefab, transform.position, Quaternion.identity, transform);
            }
            else
            {
                int obstacleSpawnIndex = Random.Range(2, 5);
                Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
                int obstacleChance = Random.Range(0, 9);

                if (obstacleChance < 8)
                {
                    int obstacleType = Random.Range(0, 2);
                    GameObject obj = Instantiate(obstacleType == 0 ? obstaclePrefab1 : obstaclePrefab2, spawnPoint.position, Quaternion.identity, transform);
                }
                else
                {
                    for (int i = 2; i <= 4; i++)
                    {
                        Transform spawnPointMulti = transform.GetChild(i).transform;
                        GameObject obj = Instantiate(obstaclePrefab3, spawnPointMulti.position, Quaternion.identity, transform);
                    }
                }
            }

            spawnEmptyToggle = !spawnEmptyToggle;
        }
    }

    void CollectableSpawn()
    {
        int collectableSpawnIndex = Random.Range(5, 8);
        Transform spawnPoint = transform.GetChild(collectableSpawnIndex).transform;
        Quaternion rotation = Quaternion.Euler(0, 0, 45);

        if (player.localScale.x < 0.0f) // when player size will reduce we will spawn cube
        {
            //GameObject sizeCube = Instantiate(sizeGainCube, spawnPoint.position, rotation, transform);
        }
        else
        {
            float spawnChance = Random.Range(0f, 1f);

            if (spawnChance < 0.3f)
            {
                GameObject sizeCube = Instantiate(sizeGainCube, spawnPoint.position, rotation, transform);
            }
            else if (spawnChance > 0.3f && spawnChance < 0.35f)
            {
                GameObject coin = Instantiate(coinPrefab, spawnPoint.position, rotation, transform);
            }
        }
    }
}
