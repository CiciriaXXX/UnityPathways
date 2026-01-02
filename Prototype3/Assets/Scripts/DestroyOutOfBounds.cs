using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float leftBounds = -15f;
    void Update()
    {
        if (transform.position.x < leftBounds)
        {
            Destroy(gameObject);
        }
    }
}
