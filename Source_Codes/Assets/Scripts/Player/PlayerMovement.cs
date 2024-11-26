using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float maxSpeed = 100f;
    public float laneChangeSpeed = 30f; 
    public float laneWidth = 3f; 
    private int currentLane = 1;
    private bool leftPressed;
    private bool rightPressed;
    public bool canMove = true;
    
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void UpdateTargetPosition()
    {
        targetPosition = new Vector3((currentLane - 1) * laneWidth, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if(canMove)
        {
            leftPressed = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
            rightPressed = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

            if (leftPressed && !rightPressed) 
            {
                if (currentLane > 0)
                {
                    currentLane--;
                    UpdateTargetPosition();
                }
            }

            if (rightPressed && !leftPressed) 
            {
                if(currentLane < 2)
                {
                    currentLane++;
                    UpdateTargetPosition();
                }
            }
        }
        
    }

    void FixedUpdate()
    {
        if (moveSpeed < maxSpeed) 
            moveSpeed += 0.7f * Time.deltaTime;

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        targetPosition = new Vector3(targetPosition.x,transform.position.y,transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);
    }

    public void EnableMovement( bool enable )
    {
        canMove = enable;
    }
}
