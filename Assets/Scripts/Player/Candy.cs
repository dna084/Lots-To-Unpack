using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyPickup : Pickup
{
    public int candyValue;

    public override void ApplyEffect(GameObject player)
    {
        player.GetComponent<Player>().IncreaseCandy(candyValue);
    }
}
