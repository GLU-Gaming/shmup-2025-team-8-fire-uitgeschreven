using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int health = 3;
    [SerializeField] Image healthBar;
    [SerializeField] float healthBarCalc;
    private GameManager game;
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        healthBar.fillAmount = health / healthBarCalc;
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
