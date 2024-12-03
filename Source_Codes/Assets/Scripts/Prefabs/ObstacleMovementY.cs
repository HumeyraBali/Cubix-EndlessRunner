using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementY : MonoBehaviour
{
    public float speed = 2f; 
    private float minY = 0.5f;
    private float maxY = 5f;
    private float timeOffset; // Unique offset for each obstacle

    void Start()
    {
        // Assign a random time offset to this obstacle
        timeOffset = Random.Range(0f, 10f);
    }

    void Update()
    {
        // Calculate the new X position using Mathf.PingPong with the offset
        float y = Mathf.PingPong((Time.time + timeOffset) * speed, maxY - minY) + minY;

        // Update the position of the obstacle
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
