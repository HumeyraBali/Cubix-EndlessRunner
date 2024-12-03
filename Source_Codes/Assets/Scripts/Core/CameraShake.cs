using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public AnimationCurve curve;
    public float duration = 1f;
    public bool shaked = false;
    private GameOver gameOver;

    void Start()
    {
        gameOver = FindObjectOfType<GameOver>();
    }

    void Update()
    {
        if(gameOver.gameover == true && shaked == false)
        {
            StartCoroutine(Shaking());
        }
    }
    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.transform.position;
        float elapsedTime = 0f;
        shaked = true;

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strenght = curve.Evaluate(elapsedTime/duration);
            transform.position = startPosition + Random.insideUnitSphere * strenght;
            yield return null; 
        }
       
        transform.position = startPosition;

        yield return new WaitForSeconds(2);
        gameOver.DestroyAllPrefabs();
        gameOver.GameOverPanelStarter();
    }
}
