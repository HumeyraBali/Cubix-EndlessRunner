using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public bool startScore = false;

    void Start()
    {
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        playerMovement.EnableMovement(false);
        yield return new WaitForSeconds(5f);
        playerMovement.EnableMovement(true);
        startScore = true;
    }
}
