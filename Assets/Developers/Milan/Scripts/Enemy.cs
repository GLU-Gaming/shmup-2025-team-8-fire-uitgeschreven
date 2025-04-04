using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    [SerializeField] private float speed;
    private GameManager game;
    private EnemyHealth enemyHealthScript;
    private Health healthScript;
    [SerializeField] private float damage = 1;

    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindFirstObjectByType<PlayerMovement>().gameObject;
        enemyHealthScript = GetComponent<EnemyHealth>();
        healthScript = FindFirstObjectByType<Health>();
    }


    void Update()
    {
        //rb.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = direction.normalized * speed;

        rb.rotation = Quaternion.LookRotation(player.transform.position - transform.position);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            game.RemoveEnemy(gameObject);
            Destroy(gameObject);
            healthScript.TakeDamage(damage);

        }
        if (collision.gameObject.CompareTag("ProjectilesMinigun"))
        {

            enemyHealthScript.TakeDamage();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("ProjectilesHarpoon"))
        {
            enemyHealthScript.TakeDamage();
            enemyHealthScript.TakeDamage();
            enemyHealthScript.TakeDamage();
            enemyHealthScript.TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}
