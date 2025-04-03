using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    private float timer;
    private Health playerHealth;
    [SerializeField] private float damage = 20;

    private void Start()
    {
        playerHealth = FindFirstObjectByType<Health>();
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {

            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.health -= damage;
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Projectiles"))
        {
            Destroy(gameObject);
        }

    }
}
