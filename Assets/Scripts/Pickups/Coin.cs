using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] public float speedValue;
    [SerializeField] public int coinValue;

    void Update()
    {
        transform.Translate(Vector3.left * speedValue * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (transform.position.x <= -12)
        {
            Destroy(gameObject);
        }
    }

    public override void ApplyEffect(GameObject player)
    {
        player.GetComponent<Player>().IncreaseCoin(coinValue);
    }
}
