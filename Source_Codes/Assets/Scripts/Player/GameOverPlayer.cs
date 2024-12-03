using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPlayer : MonoBehaviour
{
    private GameOver gameOver;
    private void Start() 
    {
        gameOver = FindObjectOfType<GameOver>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
           gameOver.gameover = true;
        }
    }
}
