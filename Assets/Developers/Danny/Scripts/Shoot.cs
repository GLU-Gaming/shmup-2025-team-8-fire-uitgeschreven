using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{

    [SerializeField] private GameObject bullet1;
    [SerializeField] private GameObject harpoon1;
    [SerializeField] private GameObject spawnPoint;

    private GameObject bullet2;
    private GameObject harpoon2;

    private Rigidbody bulletBody;
    private Rigidbody harpoonBody;

    private float timer;
    [SerializeField] private float bulletSpeed;
    void Start()
    {
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(Input.GetKey("space"))
        {
            if(timer >= 0.1f)
            {

                bullet2 = Instantiate(bullet1, spawnPoint.transform.position, spawnPoint.transform.rotation);
                bulletBody = bullet2.GetComponent<Rigidbody>();
                bulletBody.AddForce(bullet2.transform.forward*bulletSpeed);
                timer = 0;
            }
        }
    }

}
