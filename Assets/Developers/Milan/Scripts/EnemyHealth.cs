using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] Image healthBar;
    private GameManager game;
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        healthBar.fillAmount = health / 3f;
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            game.RemoveEnemy(gameObject);
            Destroy(gameObject);
        }
    }
}
