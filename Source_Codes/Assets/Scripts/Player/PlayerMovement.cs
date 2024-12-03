using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float maxSpeed = 100f;
    public float laneChangeSpeed = 30f; 
    public float laneWidth = 3f; 
    private int currentLane = 1;
    private bool leftPressed;
    private bool rightPressed;
    public bool canMove = true;
    private int maxspeedLevel1 = 30;
    private int maxspeedLevel2 = 40;
    public int maxspeedLevel3 = 50;

    private GameTimeManager timer;
    
    private Vector3 targetPosition;

    void Start()
    {
        timer = FindObjectOfType<GameTimeManager>();
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
        {
            if( 15 < timer.timer && timer.timer < 50  && moveSpeed < maxspeedLevel1) // Level 1
                moveSpeed += 0.7f * Time.deltaTime;
            else if(60 <timer.timer && timer.timer < 90 && moveSpeed < maxspeedLevel2) // Level 2
                moveSpeed += 0.7f * Time.deltaTime;
        }
           

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        targetPosition = new Vector3(targetPosition.x,transform.position.y,transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);
    }

    public void EnableMovement( bool enable )
    {
        canMove = enable;
    }
}
