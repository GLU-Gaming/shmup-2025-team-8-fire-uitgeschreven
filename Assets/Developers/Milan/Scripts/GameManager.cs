using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
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
    public bool isBossFightStart = false;
    private bool isGamePaused = false;
    private CameraFollowsPlayer cameraFollowsPlayer;
    private GameObject RandomEnemy;
    public bool isWaveCleared = false;
    public int minEnemy = 1;
    public int maxEnemy = 5;
    private int wavesLeft = 1;
    private int wavesMax = 2;
    [SerializeField] private GameObject miniPlayer;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject bossSpawnLocation;
    public bool hasBossSpawned = false;

    void Start()
    {
        StartWave();
        cameraFollowsPlayer = FindFirstObjectByType<CameraFollowsPlayer>();
    }

    public void ResetWaves()
    {
        wavesLeft = 1;
        wavesMax++;
    }


    private void Update()
    {
        int wavesLeftText = wavesLeft;
        if (isWaveCleared == false )
        {
            waveText.text = "Wave: " + wavesLeftText + "/" + wavesMax;
        }
        else if (hasBossSpawned == true)
        {
            waveText.text = "Wave: ???";
        }
        if (enemies.Count == 0 && wavesLeft == wavesMax && hasBossSpawned == false)
        {
            isWaveCleared = true;
        }
        else if (enemies.Count == 0 && wavesLeft <= wavesMax)
        {
            wavesLeft++;
            StartWave();
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
        if (miniPlayer.transform.position.y <= -2.939981f)
        {

            if (hasBossSpawned == false)
            {
              
                SpawnBoss();
                hasBossSpawned = true;

            }  
        }

    }
    private void SpawnBoss()
    {
        Instantiate(bossPrefab, bossSpawnLocation.transform.position, bossSpawnLocation.transform.rotation);
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
