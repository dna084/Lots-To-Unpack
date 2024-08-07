using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Pickup
{
    public int coinValue;

    public override void ApplyEffect(GameObject player)
    {
        player.GetComponent<Player>().IncreaseCoin(coinValue);
    }
}
