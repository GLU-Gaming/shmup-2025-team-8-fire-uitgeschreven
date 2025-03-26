using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] public float speed = 30;
    [SerializeField] private float RotationSpeed = 10f;
    private Health healthScript;


    [SerializeField] private float deeperPower;
    void Start()
    {
        healthScript = FindFirstObjectByType<Health>();
        rb = GetComponent<Rigidbody>();
    }

   
    void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.up * speed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(Vector3.down * speed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * RotationSpeed);
            if (transform.eulerAngles.y > 175 || transform.eulerAngles.y < -175)
            {
                rb.AddRelativeForce(Vector3.right * speed, ForceMode.Acceleration);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * RotationSpeed);
            if (transform.eulerAngles.y < 5 || transform.eulerAngles.y > 355)
            {
                rb.AddRelativeForce(Vector3.right * speed, ForceMode.Acceleration);
            }
        }

     
    }

    public void GoDeeper()
    {
        if (transform.rotation.y == 0)
        {
            rb.AddRelativeForce(new Vector3(-deeperPower, deeperPower, 0f), ForceMode.Impulse);
        }
        if (transform.rotation.y == 180)
        {
            rb.AddRelativeForce(new Vector3(deeperPower, -deeperPower, 0f), ForceMode.Impulse);
        }   
    }
    
}
