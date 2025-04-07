using UnityEngine;

public class Particles : MonoBehaviour
{
    private float timer;
    [SerializeField] private GameObject collisionParticles;
    private void Start()
    {

    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= 0.2)
        {
            Destroy(gameObject);
        }
    }
}
