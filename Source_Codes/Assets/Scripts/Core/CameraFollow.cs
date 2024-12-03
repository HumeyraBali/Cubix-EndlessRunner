using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; 
    private Vector3 offset = new Vector3(0, 6.66f, -15f); // Fixed offset from the player
    private Vector3 rotationOffset = new Vector3(13.189f, 0, 0);
    private GameOver gameOver;

    void Start()
    {
        gameOver = FindObjectOfType<GameOver>();
    }


    void LateUpdate()
    {
        if (!gameOver.gameover)
            transform.position = new Vector3( offset.x, offset.y, player.position.z + offset.z );

            Quaternion targetRotation = Quaternion.Euler(rotationOffset);
            transform.rotation = targetRotation;

            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}

