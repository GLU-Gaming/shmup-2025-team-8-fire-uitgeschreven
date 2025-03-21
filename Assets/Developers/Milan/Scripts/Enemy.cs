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
        player = GameObject.Find("Player");
    }

  
    void Update()
    {
        rb.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        rb.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            game.RemoveEnemy(gameObject);
            
        }
        if (collision.gameObject.CompareTag("Projectile"))
            {
            game.RemoveEnemy(gameObject);
            Destroy(collision.gameObject);
        }


    }
}
