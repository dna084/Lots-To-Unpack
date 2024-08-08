using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] public float speedValue;

    void Update()
    {
        transform.Translate(Vector3.left * speedValue * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if (transform.position.x <= -27.75f)
        {
            Destroy(gameObject);
        }
    }

}
