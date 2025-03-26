using System.Threading;
using UnityEngine;

public class MineExplode : MonoBehaviour
{
    private Health healthScript;
    private SphereCollider sphereCollider;
    private float timer;
    void Start()
    {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        healthScript = FindFirstObjectByType<Health>();
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            healthScript.health -= 35;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

}
