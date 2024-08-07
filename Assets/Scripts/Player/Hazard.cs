using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardPickup : Pickup
{
    public int damage = 1;

    public override void ApplyEffect(GameObject player)
    {
        player.GetComponent<Player>().TakeDamage(damage);
    }
}
