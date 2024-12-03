using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    public float timer;   

    void Start()
    {
        ResetTimer(); 
    }

    void Update()
    {
        UpdateTimer();
    }

    public void ResetTimer()
    {
        timer = 0f;
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime; 
    }

    public float GetTimer()
    {
        return timer;
    }

}
