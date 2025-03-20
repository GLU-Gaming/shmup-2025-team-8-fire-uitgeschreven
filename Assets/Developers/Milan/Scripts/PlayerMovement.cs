using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float RotationSpeed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
    
     
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector3(0, 1, 0) * speed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(new Vector3(0, -1, 0) * speed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * RotationSpeed);
            if (transform.rotation.y >= 175)
            {
                rb.AddRelativeForce(new Vector3(1, 0, 0) * speed, ForceMode.Acceleration);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * RotationSpeed);
            if (transform.rotation.y <= 5)
            {
                rb.AddRelativeForce(new Vector3(1, 0, 0) * speed, ForceMode.Acceleration);
            }
        }


    }
}
