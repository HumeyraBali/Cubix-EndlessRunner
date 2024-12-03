using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeParticleController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public ParticleSystem particleSystem;
    private ParticleSystem.MainModule particleMain;
    private float playerSpeed;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        if (particleSystem != null)
        {
            particleMain = particleSystem.main;
        }
    }

    void Update()
    {
        if (particleSystem != null)
        {
            playerSpeed = playerMovement.moveSpeed;

            particleMain.simulationSpeed = playerSpeed / 10;
        }
    }

}
