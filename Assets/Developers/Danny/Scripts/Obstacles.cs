using UnityEngine;

public class Obstacles : MonoBehaviour
{

    private Health healthScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthScript = FindFirstObjectByType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthScript.health -= 10;
        }
    }
}
