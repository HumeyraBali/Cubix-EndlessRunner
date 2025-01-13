using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    public GameObject ground;
    public GameObject grid;
    Vector3 nextSpawnPoint;
    Vector3 nextSpawnPointGrid;

    public GameObject SpawnGround()
    {
        GameObject temp = Instantiate(ground, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        return temp;
    }
    public GameObject SpawnGrid()
    {
        GameObject temp = Instantiate(grid, nextSpawnPointGrid, Quaternion.identity);
        nextSpawnPointGrid = temp.transform.GetChild(0).transform.position;
        return temp;
    }
    void Start()
    {
        nextSpawnPoint = new Vector3(0, 0, 70);
        for (int i = 0; i < 15; i++)
        {
            SpawnGround();
        }

        nextSpawnPointGrid = new Vector3(0, 0, 5000);
        SpawnGrid();
 
    }
}
