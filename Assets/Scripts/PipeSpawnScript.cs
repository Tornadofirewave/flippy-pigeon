using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float heightOffset = 10f;

    private float nextSpawnTime = 0f;

    void Start()
    {
        // Spawn a pipe immediately
        SpawnPipe();
        // Set the next spawn time
        nextSpawnTime = Time.time + spawnRate;
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnPipe();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float spawnY = Random.Range(lowestPoint, highestPoint);
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnY, 0);

        GameObject newPipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
        newPipe.transform.SetParent(transform);
    }
}
