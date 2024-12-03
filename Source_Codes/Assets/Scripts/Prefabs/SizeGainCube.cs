using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SizeGainCube : MonoBehaviour
{
    private Transform player;
    public float[] targetScales = { 0.51f, 0.6f, 0.7f, 0.8f, 0.9f }; 
    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void OnCollisionEnter(Collision collision)  
    {
        this.gameObject.SetActive(false);
        
        if(player.localScale.x < 0.9f)
            player.localScale = player.localScale + new Vector3(0.1f, 0.1f, 0.1f);

        else
            player.localScale = Vector3.one; 
    }

}
