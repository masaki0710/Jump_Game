using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] modulePrefabs;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= GameConfig.SpawnInterval)
        {
            SpawnPlatform();
            timer = 0;
        }
    }

    void SpawnPlatform()
    {
        if (modulePrefabs.Length == 0) return;

        // ランダムにプレハブを選択
        int index = Random.Range(0, modulePrefabs.Length);

        // 生成
        Instantiate(modulePrefabs[index], transform.position, Quaternion.identity);
    }
}
