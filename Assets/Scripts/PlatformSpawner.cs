using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] modulePrefabs;
    public GameObject emptyFloorPrefab;
    public int initialRows = 4;
    public float floorLength = 13.0f;

    private float timer;

    void Start()
    {
        SpawnInitialFloors();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= GameConfig.SpawnInterval)
        {
            SpawnPlatform();
            timer = 0;
        }
    }

    void SpawnInitialFloors()
    {
        for (int i = 0; i < initialRows; i++)
        {
            Vector3 spawnPos = transform.position - (Vector3.right * floorLength * i);

            GameObject prefabToSpawn = emptyFloorPrefab != null ? emptyFloorPrefab : modulePrefabs[0];
            Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
        }
    }

    void SpawnPlatform()
    {
        if (modulePrefabs.Length == 0) return;

        int index = Random.Range(0, modulePrefabs.Length);
        Instantiate(modulePrefabs[index], transform.position, Quaternion.identity);
    }
}
