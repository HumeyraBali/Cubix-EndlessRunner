using UnityEngine;

public class TrailControl : MonoBehaviour
{
    public TrailRenderer[] trails; 
    private PlayerMovement playerMovement; 
    private float previousSpeed = 10f; 

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        if (trails == null || trails.Length == 0)
        {
            trails = GetComponentsInChildren<TrailRenderer>(); 
        }
    }

    void Update()
    {
        float currentSpeed = playerMovement.moveSpeed;
        bool shouldEmit = currentSpeed > previousSpeed;
        
        foreach (TrailRenderer trail in trails)
        {
            if (trail.emitting != shouldEmit)
            {
                trail.emitting = shouldEmit;
            }
        }
        
        previousSpeed = currentSpeed;
    }
}
