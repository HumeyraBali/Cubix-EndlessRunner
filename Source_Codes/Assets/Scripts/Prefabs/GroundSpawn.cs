using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    public GameObject ground;
    Vector3 nextSpawnPoint;

    public void SpawnGround()
    {
        GameObject temp = Instantiate(ground, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
    void Start()
    {
        nextSpawnPoint = new Vector3(0, 0, 70);
        for (int i = 0; i < 30; i++)
        {
            SpawnGround();
        }
    }
}
