using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player; 
    private Rigidbody rb;
    [SerializeField] private float speed;
    private GameManager game;
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindFirstObjectByType<PlayerMovement>().gameObject;
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
            //game.RemoveEnemy(gameObject);
            
        }
        if (collision.gameObject.CompareTag("Projectiles"))
            {
            game.RemoveEnemy(gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }


    }
}
