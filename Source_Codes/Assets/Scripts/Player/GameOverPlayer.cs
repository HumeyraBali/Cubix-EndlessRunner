using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPlayer : MonoBehaviour
{
    public bool gameover = false;
    private PlayerMovement playerMovement;
    ScoreManager scoreManager;
    Collectables collectables;
    private void Start() 
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        scoreManager = FindObjectOfType<ScoreManager>();
        collectables = FindObjectOfType<Collectables>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameover = true;
            playerMovement.moveSpeed = 0f;
            scoreManager.SaveHighScore();
            collectables.SaveCoins();
        }
    }
}
