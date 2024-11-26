using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    Collectables collectables;
    private void Start() 
    {
        collectables = FindObjectOfType<Collectables>();
    }
    private void OnCollisionEnter(Collision collision) 
    {
        this.gameObject.SetActive(false);
        collectables.currentCoins += 1;
    }
}
