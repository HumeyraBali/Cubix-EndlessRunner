using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnMainMenu : MonoBehaviour
{
    public GameObject groundMenu;
    Vector3 nextSpawnPoint;

    public GameObject SpawnGroundMenu()
    {
        GameObject temp = Instantiate(groundMenu, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        return temp;
    }
    void Start()
    {
        nextSpawnPoint = new Vector3(0, 0, 45);
        for (int i = 0; i < 30; i++)
        {
            SpawnGroundMenu();
        }
    }
}
