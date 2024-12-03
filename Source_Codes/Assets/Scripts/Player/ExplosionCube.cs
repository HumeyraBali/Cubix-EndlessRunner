using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCube : MonoBehaviour
{
    public int cubesPerAxis = 8;
    public float force = 300f;
    public float radius = 2f;
    public Camera playerCamera;

    private GameOver gameOver;
    private bool cubesCreated = false;

    private void Start()
    {
        gameOver = FindObjectOfType<GameOver>();
    }

    void Update()
    {
        if (gameOver != null && gameOver.gameover && !cubesCreated)
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

        if (playerCamera != null)
        {
            playerCamera.transform.parent = null;
        }

        gameObject.SetActive(false);

        yield return null; 
    }

    private void CreateCube(Vector3 coordinates)
    {
        // Create a new cube GameObject
        GameObject cube = new GameObject("ExplodedCube");

        // Add components to the cube
        cube.AddComponent<MeshFilter>().mesh = GetComponent<MeshFilter>().mesh; // Copy the mesh
        MeshRenderer originalRenderer = GetComponent<MeshRenderer>();
        MeshRenderer cubeRenderer = cube.AddComponent<MeshRenderer>();

        // Assign all materials from the original object
        cubeRenderer.materials = originalRenderer.materials;

        // Scale and position the new cube
        cube.transform.localScale = transform.localScale / cubesPerAxis;
        Vector3 firstCubePosition = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstCubePosition + Vector3.Scale(coordinates, cube.transform.localScale);

        // Add Rigidbody and apply explosion force
        Rigidbody rb = cube.AddComponent<Rigidbody>();
        cube.AddComponent<BoxCollider>();
        rb.mass = 1f;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.AddExplosionForce(force, transform.position, radius);

        cube.tag = "LittleCubes";
    }
}
