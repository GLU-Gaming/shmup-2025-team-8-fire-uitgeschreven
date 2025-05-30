using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    private Image healthBar;
    private GameManager game;
    [SerializeField] public float health;
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        healthBar = GameObject.Find("Boss Fill health").GetComponent<Image>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / 5000f;

    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            game.isCelebrating = true;
            game.celebrationTimer = 3f;

        }
    }
}
