using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player; 
    private Rigidbody rb;
    [SerializeField] private float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

  
    void Update()
    {
        rb.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        rb.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
    }
}
