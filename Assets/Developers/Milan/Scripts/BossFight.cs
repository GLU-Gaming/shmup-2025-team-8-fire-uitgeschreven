using UnityEngine;

public class BossFight : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject upperWall;
    private GameObject player;
    private GameObject lowerWall;
    private bool goLeft = true;
    private Health playerHealth;
    private BossHealth bossHealth;
    [SerializeField] private int stage = 1;
    //[SerializeField] private List<Material> materials;
    private MeshRenderer meshRenderer;
    [SerializeField] private GameObject projectile;
    float cooldown = 1;
    private bool isDown = true;
    private float wallTimer = 0.5f;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        upperWall = GameObject.Find("UpperWall1");
        lowerWall = GameObject.Find("LowerWall1");
        playerHealth = FindFirstObjectByType<Health>();
        bossHealth = GetComponent<BossHealth>();
        meshRenderer = GetComponent<MeshRenderer>();

    }

    void Update()
    {
        wallTimer -= Time.deltaTime;
        upperWall.transform.rotation = Quaternion.Slerp(upperWall.transform.rotation, Quaternion.Euler(0, 0, 20), 0.03f);
        lowerWall.transform.rotation = Quaternion.Slerp(lowerWall.transform.rotation, Quaternion.Euler(0, 0, 20), 0.03f);
        if (wallTimer <= 0)
        {
            lowerWall.transform.position = new Vector3(-13, 2.5f, lowerWall.transform.position.z);
            upperWall.transform.position = new Vector3(-15.2f, 1f, upperWall.transform.position.z);

            wallTimer = 0.5f;
        }
        if (stage == 1)
        {
            //meshRenderer.material = materials[0];

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
                rb.position = new Vector3(transform.position.x - 0.4f, 3.3f, transform.position.z);
                rb.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (goLeft == false)
            {
                rb.position = new Vector3(transform.position.x + 0.4f, -1.77f, transform.position.z);
                rb.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (bossHealth.health <= 3750)
            {
                NextStage();

            }
        }
#if UNITY_EDITOR

        if (Input.GetKeyUp(KeyCode.P))
        {
            NextStage();
        }

#endif
        if (stage == 2)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            GameObject bulletClone;
            //meshRenderer.material = materials[1];

            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                bulletClone = Instantiate(projectile, transform.position, transform.rotation);
                bulletClone.GetComponent<Rigidbody>().linearVelocity = (player.transform.position - transform.position).normalized * 10;
                cooldown = 1;
            }
            if (transform.position.y <= -2.05f)
            {
                isDown = true;
            }
            if (transform.position.y >= 4.1f)
            {
                isDown = false;
            }
            if (isDown == true)
            {
                rb.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 4.40f, 0), 0.03f);
            }
            else
            {
                rb.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -2.44f, 0), 0.03f);
            }

            if (bossHealth.health <= 2500)
            {
                NextStage();
            }

        }

        if (stage == 3)
        {
            //meshRenderer.material = materials[2];

            if (transform.position.y <= -2.25f)
            {
                isDown = true;
            }
            if (transform.position.y >= 4.23f)
            {
                isDown = false;
            }
            if (isDown == true)
            {
                rb.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, 4.40f, 0), 0.03f);
            }
            else
            {
                rb.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -2.44f, 0), 0.03f);
            }
        }




    }



    private void NextStage()
    {
        bool doneMoving = false;
        transform.position = Vector3.Lerp(transform.position, new Vector3(8.79f, 1, 0), 0.01f);
        if (transform.position.x >= 8.39f && transform.position.y >= 0.9f && transform.position.y <= 1.1f)
        {
            doneMoving = true;
        }
        if (doneMoving == true)
        {
            stage++;
            transform.localScale = new Vector3(2.79f + 0.5f, 2.79f + 0.5f, 2.79f + 0.5f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(40);
            bossHealth.TakeDamage(20);
        }
        if (collision.gameObject.CompareTag("ProjectilesMinigun"))
        {
            bossHealth.TakeDamage(50);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("ProjectilesHarpoon"))
        {
            bossHealth.TakeDamage(100);
            Destroy(collision.gameObject);
        }
    }
}
