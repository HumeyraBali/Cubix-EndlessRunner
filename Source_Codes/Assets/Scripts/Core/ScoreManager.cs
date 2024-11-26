using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int playerScore = 0; // The current score
    DistanceDisplay distanceDisplay;
    private void Start() 
    {
        distanceDisplay = GetComponent<DistanceDisplay>();
    }

    private void Update() 
    {
        playerScore = distanceDisplay.disRun;
    }

    public void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", playerScore); 
            PlayerPrefs.Save(); 
        }
    }
}
