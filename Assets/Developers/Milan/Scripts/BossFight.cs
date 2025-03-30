using UnityEngine;

public class BossFight : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject upperWall;
    private GameObject lowerWall;
    private bool goLeft = true;
    private Health playerHealth;
    private BossHealth bossHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        upperWall = GameObject.Find("UpperWall");
        lowerWall = GameObject.Find("LowerWall");
        playerHealth = FindFirstObjectByType<Health>();
        bossHealth = GetComponent<BossHealth>();
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

        if (goLeft == true && upperWall.transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            rb.position = new Vector3(transform.position.x - 0.35f, 3.3f, transform.position.z);
            rb.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (goLeft == false && upperWall.transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            rb.position = new Vector3(transform.position.x + 0.35f, -1.77f, transform.position.z);
            rb.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(40);
            bossHealth.TakeDamage(20);
        }
        if (collision.gameObject.CompareTag("Projectiles"))
        {
            bossHealth.TakeDamage(50);
            Destroy(collision.gameObject);
        }
    }
}
