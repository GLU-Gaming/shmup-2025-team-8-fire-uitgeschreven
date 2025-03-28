using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.Rendering;

public class BossFight : MonoBehaviour
{
    [SerializeField] private GameObject miniPlayer;
    private GameManager game;
    private Rigidbody rb;
    private GameObject upperWall;
private GameObject lowerWall;
    private bool goLeft = true;
    private Health health;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        upperWall = GameObject.Find("UpperWall");
        lowerWall = GameObject.Find("LowerWall");
        health = FindFirstObjectByType<Health>();
        game = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        upperWall.transform.rotation = Quaternion.Slerp(upperWall.transform.rotation, Quaternion.Euler(0, 0, 0), 0.03f);
        upperWall.transform.position = new Vector3(upperWall.transform.position.x, 7.30f, upperWall.transform.position.z);
        lowerWall.transform.rotation = Quaternion.Slerp(lowerWall.transform.rotation, Quaternion.Euler(0, 0, 0), 0.03f);
        lowerWall.transform.position = new Vector3(lowerWall.transform.position.x, -5.4f, lowerWall.transform.position.z);
    
        if (transform.position.x <= -20f)
        {
            goLeft = false;
        }
        else if (transform.position.x >= 20f)
        {
            goLeft = true;
        }

        if (goLeft == true)
        {
            rb.position = new Vector3(transform.position.x - 0.1f, 3.3f, transform.position.z);
        }
        else
        {
           rb.position = new Vector3(transform.position.x + 0.1f, -1.77f, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health.TakeDamage(40);
        }
    }
}
