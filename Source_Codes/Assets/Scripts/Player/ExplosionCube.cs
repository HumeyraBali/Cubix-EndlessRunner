using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCube : MonoBehaviour
{
    public int cubesPerAxis = 8;
    public float force = 300f;
    public float radius = 2f;
    public Camera playerCamera;
    private GameOverPlayer gameOver;
    private bool cubesCreated = false;

    private void Start() 
    {
        gameOver = GetComponent<GameOverPlayer>();
    }

    void Update()
    {
        if(gameOver.gameover == true && !cubesCreated)
        {
            StartCoroutine(Main());
        }
    }

    IEnumerator Main()
    {
        for (int x = 0; x < cubesPerAxis; x++)
        {
            for (int y = 0; y < cubesPerAxis; y++)
            {
                for (int z = 0; z < cubesPerAxis; z++)
                {
                    CreateCube(new Vector3(x, y, z));
                }
            }
        }

        cubesCreated = true;

        playerCamera.transform.parent = null;
        gameObject.SetActive(false);
        yield return new WaitForSeconds(0);
    }

    private void CreateCube(Vector3 coordinates)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Renderer rd = cube.GetComponent<Renderer>();
        rd.material = GetComponent<Renderer>().material;

        cube.transform.localScale = transform.localScale / cubesPerAxis;

        Vector3 firstCube = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);

        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.mass = 1f; // Adjust mass as needed
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; 
        rb.AddExplosionForce(force, transform.position, radius);

    }
}
