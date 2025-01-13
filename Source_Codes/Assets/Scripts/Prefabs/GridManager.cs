using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    GroundSpawn groundSpawn;

    void Start()
    {   
        groundSpawn = GameObject.FindObjectOfType<GroundSpawn>();
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject newGround = groundSpawn.SpawnGrid();
        Destroy(gameObject, 4);
    }

}
