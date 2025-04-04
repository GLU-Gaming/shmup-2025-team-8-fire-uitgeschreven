using UnityEngine;

public class BabySpawner : MonoBehaviour
{
    [SerializeField] private GameObject babyPrefab;
    [SerializeField] private GameObject spawnLocation;
    private float spawnTimer = 4f;
    void Start()
    {

    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnBaby();
            spawnTimer = 4f;
        }
    }

    void SpawnBaby()
    {
        Instantiate(babyPrefab, spawnLocation.transform.position, Quaternion.identity);
    }
}
