using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsSound : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip cubeSound; 
    public AudioClip coinSound; 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            PlaySound(coinSound);
        }

        if (collision.gameObject.CompareTag("SizeGainCube"))
        {
            PlaySound(cubeSound);
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
