using UnityEngine;

public class Particles : MonoBehaviour
{
    private float timer;
    [SerializeField] private GameObject collisionParticles;

    private float particleTimer;
    private void Start()
    {

    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (particleTimer >= 0.2)
        {
            Destroy(gameObject);
        }
    }
}
