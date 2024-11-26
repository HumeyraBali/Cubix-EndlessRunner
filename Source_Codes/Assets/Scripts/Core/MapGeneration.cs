using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject[] terrain;
    public int zPos = 100;
    public bool creatingTerrain = false;
    public int terNum;
    private float timeGenerate = 2;
    public PlayerMovement playerMovement;

    private void Start() 
    {
        GameObject playerObject = GameObject.Find("Player");
        playerMovement = playerObject.GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (playerMovement.moveSpeed > 50f) timeGenerate = 1f;

        if (creatingTerrain == false)
        {
            creatingTerrain = true;
            StartCoroutine(GenerateTerrain());
        }
    }

    IEnumerator GenerateTerrain()
    {
        terNum = Random.Range(0,3);
        Instantiate(terrain[terNum], new Vector3(0,0,zPos), Quaternion.identity);
        zPos += 100;
        yield return new WaitForSeconds(timeGenerate);
        creatingTerrain = false;
    }
}
