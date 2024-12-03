using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementX : MonoBehaviour
{
    public float speed = 2f; 
    private float minX = -3.3f;
    private float maxX = 3.3f;
    private float timeOffset; // Unique offset for each obstacle

    void Start()
    {
        // Assign a random time offset to this obstacle
        timeOffset = Random.Range(0f, 10f);
    }

    void Update()
    {
        // Calculate the new X position using Mathf.PingPong with the offset
        float x = Mathf.PingPong((Time.time + timeOffset) * speed, maxX - minX) + minX;

        // Update the position of the obstacle
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
