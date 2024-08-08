using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPickup : MonoBehaviour
{

    [SerializeField] public float speedValue;
    [SerializeField] public int specialValue;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (specialValue == 1)
            {
                other.GetComponent<Player>().HealDamage();
            }
            
            else if (specialValue == 2)
            {
                other.GetComponent<Player>().SpeedUp();
            }

            else if(specialValue == 3)
            {
                if (other.GetComponent<Player>() != null) 
                {
                    other.GetComponent<Player>().StartInvincibility();
                }

            }

            Destroy(gameObject);

        }
    }

}
