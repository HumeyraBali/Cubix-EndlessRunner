using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource audioSource;  // Reference to the AudioSource
    public float maxVolume = 1.0f;   // Maximum volume level
    public float fadeDuration = 2.0f;  // Duration of fade-in and fade-out
    public float playDuration = 10.0f; // Duration the music stays at max volume

    private enum FadeState { FadingIn, Playing, FadingOut, Stopped }
    private FadeState fadeState = FadeState.FadingIn;

    private float fadeSpeed;
    private float playTimer;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        audioSource.volume = 0.5f; // Start with zero volume
        audioSource.Play();       // Start playing the music

        fadeSpeed = maxVolume / fadeDuration; // Calculate fade speed
    }

    void Update()
    {
        switch (fadeState)
        {
            case FadeState.FadingIn:
                // Gradually increase the volume
                audioSource.volume += fadeSpeed * Time.deltaTime;
                if (audioSource.volume >= maxVolume)
                {
                    audioSource.volume = maxVolume;
                    fadeState = FadeState.Playing;
                    playTimer = 0f; // Reset play timer
                }
                break;

            case FadeState.Playing:
                // Keep track of how long the music has been playing
                playTimer += Time.deltaTime;
                if (playTimer >= playDuration)
                {
                    fadeState = FadeState.FadingOut;
                }
                break;

            case FadeState.FadingOut:
                // Gradually decrease the volume
                audioSource.volume -= fadeSpeed * Time.deltaTime;
                if (audioSource.volume <= 0.0f)
                {
                    audioSource.volume = 0.0f;
                    fadeState = FadeState.FadingIn; // Start fading in again
                }
                break;

            case FadeState.Stopped:
                // Optionally handle stopping logic here
                break;
        }
    }

}
