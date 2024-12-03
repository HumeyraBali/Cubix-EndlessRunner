using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    public GameObject ground;
    Vector3 nextSpawnPoint;

    public GameObject SpawnGround()
    {
        GameObject temp = Instantiate(ground, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        return temp;
    }
    void Start()
    {
        nextSpawnPoint = new Vector3(0, 0, 70);
        for (int i = 0; i < 10; i++)
        {
            SpawnGround();
        }
    }
}
