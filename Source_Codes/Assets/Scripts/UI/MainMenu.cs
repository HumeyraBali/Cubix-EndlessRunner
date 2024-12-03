using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text highScoreText;
    public TMP_Text coinsText;
    private GameTimeManager timer;

    void Start()
    {
        timer = FindObjectOfType<GameTimeManager>();

        int highScore = PlayerPrefs.GetInt("HighScore", 0); 
        highScoreText.text = highScore.ToString();

        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0); 
        coinsText.text = totalCoins.ToString(); 
    }
    public void StartGame()
    {
        timer.ResetTimer();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
