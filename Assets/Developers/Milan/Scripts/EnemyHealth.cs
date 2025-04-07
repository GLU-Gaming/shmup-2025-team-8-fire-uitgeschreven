using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int health = 3;
    [SerializeField] Image healthBar;
    [SerializeField] float healthBarCalc;
    private GameManager game;
    private Score score;
    private int randomNumber;
    [SerializeField] List<GameObject> powerPrefabs;
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        score = FindFirstObjectByType<Score>();
    }

    void Update()
    {
        healthBar.fillAmount = health / healthBarCalc;
    }

    public void TakeDamage()
    {
        score.amountScore += 30;
        health--;
        if (health <= 0)
        {
            int randomPrefab = Random.Range(0, powerPrefabs.Count);
            randomNumber = Random.Range(0, 4);
            if (randomNumber == 3)
            {
                Instantiate(powerPrefabs[randomPrefab], transform.position, powerPrefabs[randomPrefab].transform.rotation);
            }
            game.RemoveEnemy(gameObject);
            score.amountScore += 50;
            Destroy(gameObject);
        }
    }
}
