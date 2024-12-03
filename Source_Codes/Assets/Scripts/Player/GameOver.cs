using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool gameover = false;
    private PlayerMovement playerMovement;
    private ScoreManager scoreManager;
    private Collectables collectables;
    public Transform player;
    public GameObject gameOverPanel;
    public GameObject scorePanel;
    public GameObject healthbar;

    private void Start() 
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        scoreManager = FindObjectOfType<ScoreManager>();
        collectables = FindObjectOfType<Collectables>();
    }

    public void Update() 
    {
        if ( gameover == true || player.localScale.x <= 0.5f )
        {
            GameOverStats();
        }
    }

    private void GameOverStats()
    {
        gameover = true;
        playerMovement.moveSpeed = 0f;
        scoreManager.SaveHighScore();
        collectables.SaveCoins();
    }


    public void DestroyAllPrefabs()
    {
        GameObject[] groundObjects = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject ground in groundObjects)
        {
            Destroy(ground);
        }

        GameObject[] coinObjects = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coin in coinObjects)
        {
            Destroy(coin);
        }

        GameObject[] obstacleObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacleObjects)
        {
            Destroy(obstacle);
        }

        GameObject[] GainObjects = GameObject.FindGameObjectsWithTag("SizeGainCube");
        foreach (GameObject Gain in GainObjects)
        {
            Destroy(Gain);
        }

        GameObject[] LittleCubesObjects = GameObject.FindGameObjectsWithTag("LittleCubes");
        foreach (GameObject LittleCubes in LittleCubesObjects)
        {
            Destroy(LittleCubes);
        }

    }

    public void GameOverPanelStarter()
    {
        gameOverPanel.SetActive(true);
        scorePanel.SetActive(false);
        healthbar.SetActive(false);
    }
}
