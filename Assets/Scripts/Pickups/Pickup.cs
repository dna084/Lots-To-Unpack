using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public abstract void ApplyEffect(GameObject player);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ApplyEffect(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("SpawnWall"))
        {
            Destroy(this.gameObject);
        }
    }
}
