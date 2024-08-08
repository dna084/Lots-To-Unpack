using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBounds : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Money"))
        {
            Destroy(other.gameObject);
        }
    }
}
