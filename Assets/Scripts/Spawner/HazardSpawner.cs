using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    [SerializeField] private float hazardWait = 2.0f;
    [SerializeField] private GameObject[] hazardPrefabs;
    [SerializeField] private GameObject tootie;
    [SerializeField] private float stageTimer = 30.0f;

    private bool spawning = true;
    Vector3 spawnPosition;

    void Start()
    {
        StartCoroutine(StageTimerCoroutine());
        InvokeRepeating("SpawnHazard", hazardWait, hazardWait);
    }

    void SpawnHazard()
    {
        if (!spawning) return;

        GameObject prefabToSpawn = hazardPrefabs[Random.Range(0, hazardPrefabs.Length)];

        spawnPosition = new Vector3(10, -2.5f, 0);

        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    IEnumerator StageTimerCoroutine()
    {
        yield return new WaitForSeconds(stageTimer);
        spawning = false;
        spawnPosition = new Vector3(7.0f, 1.5f, 0);
        Instantiate(tootie, spawnPosition, Quaternion.identity);
    }
}
