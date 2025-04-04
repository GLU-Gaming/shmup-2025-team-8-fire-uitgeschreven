using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject spawnLocation;
    [SerializeField] List<GameObject> enemies;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] private int amountOfEnemys = 2;
    [SerializeField] private GameObject enemySpawnLocation1;
    [SerializeField] private GameObject enemySpawnLocation2;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject miniPlayer;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject bossSpawnLocation;
    [SerializeField] private GameObject bossHealthbar;
    [SerializeField] private GameObject seaMine;
    [SerializeField] private GameObject seaUrchin;
    private int wavesLeft = 1;
    private bool isGamePaused = false;
    private CameraFollowsPlayer cameraFollowsPlayer;
    private GameObject RandomEnemy;
    private int wavesMax = 2;
    public bool isBossFightStart = false;
    public bool isWaveCleared = false;
    public int minEnemy = 1;
    public int maxEnemy = 5;
    public float celebrationTimer;
    public bool isCelebrating = false;
    public bool hasBossSpawned = false;

    void Start()
    {
        StartWave();
        cameraFollowsPlayer = FindFirstObjectByType<CameraFollowsPlayer>();
    }
    public void PauseGame()
    {
        isGamePaused = !isGamePaused;
    }
    public void ResetWaves()
    {
        wavesLeft = 1;
        wavesMax++;
    }


    private void Update()
    {
        int wavesLeftText = wavesLeft;
        if (hasBossSpawned == false)
        {
            if (isWaveCleared == false)
            {
                waveText.text = "Wave: " + wavesLeftText + "/" + wavesMax;
            }

            if (enemies.Count == 0 && wavesLeft == wavesMax && hasBossSpawned == false)
            {
                isWaveCleared = true;
            }
            else if (enemies.Count == 0 && wavesLeft <= wavesMax && hasBossSpawned == false)
            {
                wavesLeft++;
                StartWave();
            }
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

        if (isCelebrating == true)
        {
            celebrationTimer -= Time.deltaTime;
            if (celebrationTimer <= 0)
            {
                SceneManager.LoadScene("Win Screen");
            }
        }
        if (miniPlayer.transform.position.y <= -2.81135)
        {
            bossHealthbar.SetActive(true);
            waveText.text = "Wave: ???";

            if (hasBossSpawned == false)
            {
                isWaveCleared = false;
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
        Instantiate(seaMine, new Vector3(Random.Range(-11f, 10f), Random.Range(7f, -4f), 0), Quaternion.identity);
        Instantiate(seaUrchin, new Vector3(Random.Range(-11f, 10f), Random.Range(7f, -4f), 0), Quaternion.identity);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
