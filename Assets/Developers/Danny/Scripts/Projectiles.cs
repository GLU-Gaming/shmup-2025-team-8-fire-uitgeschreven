using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private float timer;

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
    }
}
