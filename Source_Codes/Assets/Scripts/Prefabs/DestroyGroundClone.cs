using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGroundClone : MonoBehaviour
{
    public string parentName;

    void Start()
    {
        parentName = transform.name;
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(60);
        if (parentName == "Terrain(Clone)") 
        {
            Destroy(gameObject);
        }
    }
}
