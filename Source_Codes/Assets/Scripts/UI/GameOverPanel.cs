using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    Collectables collectables;
    public TMP_Text coinText;
    public TMP_Text scoreText;
    private GameTimeManager timer;
    private ScoreManager scoreManager;
    private void Start() 
    {
        timer = FindObjectOfType<GameTimeManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        collectables = FindObjectOfType<Collectables>();

        coinText.text = "Coins: " + collectables.currentCoins.ToString();
        scoreText.text = "Score: " + scoreManager.playerScore.ToString();
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
