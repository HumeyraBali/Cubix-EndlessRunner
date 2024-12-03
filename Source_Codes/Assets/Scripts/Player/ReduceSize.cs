using UnityEngine;
using UnityEngine.Assertions.Must;

public class ReduceSize : MonoBehaviour
{
    public Vector3 shrinkRate = new Vector3(0.1f, 0.1f, 0.1f); 
    public Vector3 minimumScale = new Vector3(0.1f, 0.1f, 0.1f); 
    public Transform player;
    private GameTimeManager timer;
    public float[] targetScales = { 0.9f, 0.8f, 0.7f, 0.6f, 0.51f }; 

    private void Start() {
        timer = FindObjectOfType<GameTimeManager>();
    }
    void Update()
    {
        if (timer.timer > 5)
            // Gradually reduce the scale
            transform.localScale -= shrinkRate * Time.deltaTime;
            //Debug.Log(transform.localScale);

            // Clamp to the minimum scale
            transform.localScale = new Vector3(
                Mathf.Max(transform.localScale.x, minimumScale.x),
                Mathf.Max(transform.localScale.y, minimumScale.y),
                Mathf.Max(transform.localScale.z, minimumScale.z)
        );
    }
}
