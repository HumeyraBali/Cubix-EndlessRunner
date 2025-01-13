using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerMenu : MonoBehaviour
{
    GroundSpawnMainMenu groundSpawn;

    void Start()
    {   
        groundSpawn = GameObject.FindObjectOfType<GroundSpawnMainMenu>();
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawn.SpawnGrid();
        Destroy(gameObject, 4);
    }

}
