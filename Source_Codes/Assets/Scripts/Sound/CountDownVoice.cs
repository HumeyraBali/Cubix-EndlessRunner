using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownVoice : MonoBehaviour
{
    public AudioSource audioSource; 
    public float delayTime = 5.0f;  

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlaySound", delayTime);
    }

    void PlaySound()
    {
        audioSource.Play();
    } 
}
