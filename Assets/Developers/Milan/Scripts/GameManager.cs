using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject spawnLocation;
    [SerializeField] List<GameObject> enemies;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] private int amountOfEnemys = 2;
    [SerializeField] private GameObject enemySpawnLocation1;
    [SerializeField] private GameObject enemySpawnLocation2;
    private CameraFollowsPlayer cameraFollowsPlayer;
    private GameObject RandomEnemy;
    void Start()
    {
        StartWave();
        cameraFollowsPlayer = FindFirstObjectByType<CameraFollowsPlayer>();
    }

    private void Update()
    {
        if (enemies.Count == 0)
        {
            cameraFollowsPlayer.isWaveCleared = true;
        }
    }

    private void RandomizeEnemyAndSpawnpoint()
    {
        RandomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        amountOfEnemys = Random.Range(1, 10);
        spawnLocation.transform.position = new Vector3(enemySpawnLocation1.transform.position.x, Random.Range(enemySpawnLocation1.transform.position.y, enemySpawnLocation2.transform.position.y), 0);
    }
    public void StartWave()
    {
        GameObject enemyObject;
        for (int i = 0; i < amountOfEnemys; i++)
        {
            RandomizeEnemyAndSpawnpoint();
            enemyObject = Instantiate(RandomEnemy, spawnLocation.transform.position, spawnLocation.transform.rotation);
            enemies.Add(enemyObject);
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
