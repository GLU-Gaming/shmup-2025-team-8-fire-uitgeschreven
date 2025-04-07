using UnityEngine;

public class BabySpawner : MonoBehaviour
{
    [SerializeField] private GameObject babyPrefab;
    [SerializeField] private GameObject spawnLocation;
    private float spawnTimer = 4f;
    private GameManager game;
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
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
        GameObject babyClone = Instantiate(babyPrefab, spawnLocation.transform.position, Quaternion.identity);
        game.enemies.Add(babyClone);
    }
}
