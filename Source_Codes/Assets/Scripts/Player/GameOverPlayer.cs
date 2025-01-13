using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPlayer : MonoBehaviour
{
    private GameOver gameOver;
    public AudioSource audioSource; 
    public AudioClip crashSound; 
    public bool gameovermanuelplayer = false;
    private void Start() 
    {
        gameOver = FindObjectOfType<GameOver>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (gameovermanuelplayer == true)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                PlaySound(crashSound);
                gameOver.gameover = true;
            }
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
