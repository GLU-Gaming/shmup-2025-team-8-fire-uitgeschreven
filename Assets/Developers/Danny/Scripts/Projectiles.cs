using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private float timer;

    [SerializeField] private GameObject collisionParticles;
    [SerializeField] private GameObject collisionParticles2;

    private GameObject instCollisionParticles;
    private GameObject instCollisionParticles2;
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
