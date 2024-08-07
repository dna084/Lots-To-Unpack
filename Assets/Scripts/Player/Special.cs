using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPickup : Pickup
{
    public override void ApplyEffect(GameObject player)
    {
        player.GetComponent<Player>().ActivateSpecial();
    }
}
