using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController2 : MonoBehaviour
{
    public Transform player; 
    private Health healthScript; 
    public float[] thresholds = { 0.9f, 0.8f, 0.7f, 0.6f, 0.5f }; 
    private float previousScale;

    private void Start()
    {
        healthScript = GetComponent<Health>();
        if (player != null)
            previousScale = player.localScale.x; 
    }

    private void Update()
    {
        if (player == null || healthScript == null) return;

        float currentScale = player.localScale.x;

        // Check if the scale crosses thresholds
        foreach (float threshold in thresholds)
        {
            if (previousScale < threshold && currentScale >= threshold)
            {
                // Scale increased past a threshold
                AdjustHealth(1);
            }
            else if (previousScale > threshold && currentScale <= threshold)
            {
                // Scale decreased past a threshold
                AdjustHealth(-1);
            }
        }

        previousScale = currentScale; // Update the previous scale
    }

    private void AdjustHealth(int amount)
    {
        int newHealth = Mathf.Clamp(healthScript.currentHealth + amount, 0, 5);
        healthScript.SetHealth(newHealth);
    }

}
