using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickup : Pickup
{
    [SerializeField] public int value;

    public override void ApplyEffect(GameObject player)
    {
        player.GetComponent<Player>().IncreaseMoney(value);
    }
}
