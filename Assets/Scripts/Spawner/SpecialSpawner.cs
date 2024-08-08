using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSpawner : MonoBehaviour
{
    [SerializeField] private float wait = 10.0f;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float stageTimer = 60.0f;

    private bool spawning = true;

    void Start()
    {
        StartCoroutine(StageTimerCoroutine());
        InvokeRepeating("SpawnPickups", wait, wait);
    }

    void SpawnPickups()
    {
        if (!spawning) return;

        GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

        Vector3 spawnPosition = new Vector3(10, 0, 0);

        if (prefabToSpawn.CompareTag("Money") || prefabToSpawn.CompareTag("Coin") || prefabToSpawn.CompareTag("Special"))
        {
            float[] possibleYPositions = { 0f, 3f };
            spawnPosition.y = possibleYPositions[Random.Range(0, possibleYPositions.Length)];
        }

        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    IEnumerator StageTimerCoroutine()
    {
        yield return new WaitForSeconds(stageTimer);
        spawning = false;
    }
}
