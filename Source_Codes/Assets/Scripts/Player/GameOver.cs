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
    private bool gameoverActive = false;
    public LeaderboardData leaderboardData;
    [SerializeField] GameObject leaderboardCanvas;
    public bool gameovermanuel = false;


    private void Start() 
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        scoreManager = FindObjectOfType<ScoreManager>();
        collectables = FindObjectOfType<Collectables>();
    }

    public void Update() 
    {
        if (gameovermanuel == true)
        {
            if ( gameover == true || player.localScale.x <= 0.5f )
            {
                if (!gameoverActive)
                    GameOverStats();
                    gameoverActive = true;
            }
        }
    }

    private void GameOverStats()
    {
        gameover = true;
        playerMovement.moveSpeed = 0f;
        scoreManager.SaveHighScore();
        collectables.SaveCoins();

        if (leaderboardData != null)
        {
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            leaderboardData.Score = highScore;
        }
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
        leaderboardCanvas.SetActive(true);
        scorePanel.SetActive(false);
        healthbar.SetActive(false);
    }
}
