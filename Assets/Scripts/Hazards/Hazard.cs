using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardPickup : Pickup
{
    [SerializeField] public int damage = 1;
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
        if (player == null)
        {
            return;
        }
        player.GetComponent<Player>().TakeDamage(damage);
    }
}
