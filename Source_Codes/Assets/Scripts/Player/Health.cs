using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image[] healthSegments; 
    public int currentHealth = 5;

    public void SetHealth(int health)
    {
        currentHealth = health;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        for (int i = 0; i < healthSegments.Length; i++)
        {
            // Enable or disable each segment based on health
            healthSegments[i].enabled = i < currentHealth;
        }
    }
}

