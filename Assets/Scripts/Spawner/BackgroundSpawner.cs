using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{

    [SerializeField] GameObject background;
    [SerializeField] private GameObject backgroundMarker;

    private void Start()
    {
        SpawnBackground();
    }

    private void FixedUpdate()
    {
        backgroundMarker.transform.Translate(Vector3.left * 1 * Time.deltaTime);

        if (backgroundMarker.transform.position.x <= -9.75) { 
            SpawnBackground();
            backgroundMarker.transform.position = new Vector3(27.5f, 1,0);
        }
    }

    void SpawnBackground()
    {
        Vector3 spawnPosition = new Vector3(27.5f, 1, 0);

        Instantiate(background, spawnPosition, Quaternion.identity);
    }

}
