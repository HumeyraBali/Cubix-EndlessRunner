using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    ScoreManager scoreManager;
    Collectables collectables;
    public TMP_Text scoreText;
    public TMP_Text coinText;
    private GameTimeManager timer;
    private void Start() 
    {
        timer = FindObjectOfType<GameTimeManager>();

        scoreManager = FindObjectOfType<ScoreManager>();
        collectables = FindObjectOfType<Collectables>();

        scoreText.text = "Score: " + scoreManager.playerScore.ToString();
        coinText.text = "Coins: " + collectables.currentCoins.ToString();
    }
    public void BackToMainMenu()
    {
        timer.ResetTimer();
        collectables.currentCoins = 0;
        SceneManager.LoadScene(0);
    }

    public void ReStartGame()
    {
        timer.ResetTimer();
        collectables.currentCoins = 0;
        SceneManager.LoadScene(1);
    }
}
