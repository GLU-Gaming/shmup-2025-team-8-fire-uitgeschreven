using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Border"))
        {

        }
        else 
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

}
