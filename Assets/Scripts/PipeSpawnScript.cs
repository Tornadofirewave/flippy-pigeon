using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float heightOffset = 10f;

    private float nextSpawnTime;

    private void Start()
    {
        SpawnPipe();
        SetNextSpawnTime();
    }

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnPipe();
            SetNextSpawnTime();
        }
    }

    private void SpawnPipe()
    {
        if (pipePrefab == null)
        {
            Debug.LogError("Pipe prefab is not assigned!");
            return;
        }

        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float spawnY = Random.Range(lowestPoint, highestPoint);
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnY, 0);

        GameObject newPipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity, transform);
    }

    private void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + spawnRate;
    }
}