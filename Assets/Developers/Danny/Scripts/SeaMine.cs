using UnityEngine;

public class SeaMine : MonoBehaviour
{
    private float timer;

    [SerializeField] private GameObject seaMineRadius;
    private SphereCollider sphereCollider;
    void Start()
    {
        sphereCollider = seaMineRadius.GetComponent<SphereCollider>();

    }
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Projectiles"))
        {
            sphereCollider.enabled = true;
            Destroy(gameObject);
        }
    }
}
