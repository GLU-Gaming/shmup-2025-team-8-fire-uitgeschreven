using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player; 
    private Rigidbody rb;
    [SerializeField] private float speed;
    private GameManager game;
    private Health healthScript;
    [SerializeField] private float damage = 1;
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindFirstObjectByType<PlayerMovement>().gameObject;
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
            healthScript.TakeDamage(damage);
            game.RemoveEnemy(gameObject);
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("Projectiles"))
            {
            game.RemoveEnemy(gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
