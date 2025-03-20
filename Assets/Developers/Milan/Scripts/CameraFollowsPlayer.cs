using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollowsPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Vector3 cameraMiddle;
    [SerializeField] private Transform player;
    void Start()
    {
        
    }

    void Update()
    {
        cameraMiddle = transform.position;
        if(player.transform.position.x > transform.position.x)
        {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y + -speed * Time.deltaTime, transform.position.z);
        }
    }
}
