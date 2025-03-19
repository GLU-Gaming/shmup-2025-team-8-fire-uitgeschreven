using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y + -speed * Time.deltaTime, transform.position.z);
    }
}
