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
    private void Start() 
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        collectables = FindObjectOfType<Collectables>();

        scoreText.text = "Score: " + scoreManager.playerScore.ToString();
        coinText.text = "Coins: " + collectables.currentCoins.ToString();
    }
    public void BackToMainMenu()
    {
        collectables.currentCoins = 0;
        SceneManager.LoadScene(0);
    }

    public void ReStartGame()
    {
        collectables.currentCoins = 0;
        SceneManager.LoadScene(1);
    }
}
