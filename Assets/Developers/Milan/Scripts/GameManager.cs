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
    [SerializeField] private GameObject pauseMenu;
    private bool isGamePaused = false;
    private CameraFollowsPlayer cameraFollowsPlayer;
    private GameObject RandomEnemy;
    public bool isWaveCleared = false;
    public int minEnemy = 1;
    public int maxEnemy = 5;
    void Start()
    {
        StartWave();
        cameraFollowsPlayer = FindFirstObjectByType<CameraFollowsPlayer>();
    }

    private void Update()
    {
        if (enemies.Count == 0)
        {
            isWaveCleared = true;
        }
        if (isGamePaused == true)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
        }
    }

    private void RandomizeEnemyAndSpawnpoint()
    {
        RandomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        amountOfEnemys = Random.Range(minEnemy, maxEnemy);
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
