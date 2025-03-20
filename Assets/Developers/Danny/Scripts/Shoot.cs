using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{

    [SerializeField] private GameObject bullet1;
    [SerializeField] private GameObject harpoon1;

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

                bullet2 = Instantiate(bullet1);
                bullet2.transform.position = gameObject.transform.position;
                bullet2.transform.rotation = gameObject.transform.rotation;
                bulletBody = bullet2.GetComponent<Rigidbody>();
                bulletBody.AddForce(new Vector3(-1*bulletSpeed, 0, 0));
                timer = 0;
            }
        }
    }

}
