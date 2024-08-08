using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickup : Pickup
{
    [SerializeField] public int value;
    [SerializeField] public float speedValue;

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
        player.GetComponent<Player>().IncreaseMoney(value);
    }
}
