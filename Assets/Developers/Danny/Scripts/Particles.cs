using UnityEngine;

public class Particles : MonoBehaviour
{
    private float timer;
    private void Start()
    {


        instCollisionParticles = Instantiate(collisionParticles);
        instCollisionParticles.transform.position = transform.position;
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (particleTimer >= 0.2)
        {
            Destroy(instCollisionParticles);
        }
    }
}
