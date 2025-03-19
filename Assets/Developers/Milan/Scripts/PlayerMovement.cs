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
            rb.AddForce(Vector3.right * speed * Time.deltaTime);
        }
        rb.rotation *= Quaternion.AngleAxis(Input.GetAxisRaw("Horizontal") * RotationSpeed, new Vector3(0, 0, -1));
    }
}
