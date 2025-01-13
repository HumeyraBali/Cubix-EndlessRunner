using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    Collectables collectables;
    [SerializeField] ParticleSystem particleSystem;
    private void Start() 
    {
        collectables = FindObjectOfType<Collectables>();
    }
    private void OnCollisionEnter(Collision collision) 
    {
        ParticleSystem particleInstance = Instantiate(particleSystem, transform.position, Quaternion.identity);

        particleInstance.Play();
        Destroy(particleInstance.gameObject, particleInstance.main.duration);

        this.gameObject.SetActive(false);
        collectables.currentCoins += 1;
    }

}
