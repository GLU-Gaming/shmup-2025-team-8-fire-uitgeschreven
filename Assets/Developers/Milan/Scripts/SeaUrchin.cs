using UnityEngine;

public class SeaUrchin : MonoBehaviour
{
    private Health health;
    private bool isDamaging = false;
    private float damageTimer = 3;
    [SerializeField] private float damageAmount = 1;
    void Start()
    {
        health = FindFirstObjectByType<Health>();
    }

    void Update()
    {
        if (isDamaging == true && damageTimer >= 0)
        {
            damageTimer -= Time.deltaTime;
            health.TakeDamage(damageAmount);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isDamaging = true;
            damageTimer = 5;
        }
    }
}
