using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public int rotateSpeed = 1;
    void FixedUpdate()
    {
      transform.Rotate(rotateSpeed, rotateSpeed, rotateSpeed, Space.World);
    }
}
