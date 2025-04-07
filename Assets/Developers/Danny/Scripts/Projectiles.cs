using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private float timer;

    [SerializeField] private GameObject collisionParticles;

    private GameObject instCollisionParticles;
    private float particleTimer;
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {

            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        instCollisionParticles = Instantiate(collisionParticles);
        instCollisionParticles.transform.position = transform.position;
    }
}
