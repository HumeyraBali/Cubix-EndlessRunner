using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementY : MonoBehaviour
{
    public float speed = 2f; 
    private float minY = 0.7f;
    private float maxY = 5f;
    public float timeOffset = 0; 
    GroundManager groundManager;
    void Start()
    {
        // Assign a random time offset to this obstacle
        //timeOffset = Random.Range(0f, 10f);
        groundManager = FindObjectOfType<GroundManager>();  
    }

    void Update()
    {
        if (transform.position.x == 3.3f || transform.position.x == -3.3f) timeOffset = 0f;
        else timeOffset = 10f;
        //Debug.Log("Position:" + transform.position.x + "timeOffset:" + timeOffset);
        // Calculate the new X position using Mathf.PingPong with the offset
        float y = Mathf.PingPong((Time.time + timeOffset) * speed, maxY - minY) + minY;

        // Update the position of the obstacle
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
