using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private float timer;

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer > 2)
        {

            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Border"))
        {

        }
        else 
        {
           // Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
