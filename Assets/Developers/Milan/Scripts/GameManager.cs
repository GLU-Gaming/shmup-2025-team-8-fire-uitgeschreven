using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gulper_Eel;
    [SerializeField] GameObject fish;
    [SerializeField] GameObject spawnLocation;
    [SerializeField] List<GameObject> enemies;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] private int amountOfEnemys = 2;
    private GameObject RandomEnemy;
    void Start()
    {
        StartWave();
    }

    private void Update()
    {
        if (enemies.Count == 0)
        {
            StartWave();
        }
    }

    private void RandomizeEnemyAndSpawnpoint()
    {
        RandomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        amountOfEnemys = Random.Range(1, 10);
        spawnLocation.transform.position = new Vector3(17, Random.Range(-10, 10), 0);
    }
    private void StartWave()
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
