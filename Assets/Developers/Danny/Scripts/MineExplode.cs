using System.Threading;
using UnityEngine;

public class MineExplode : MonoBehaviour
{
    private SeaMine seaMineScript;
    private Health healthScript;
    private EnemyHealth enemyHealthScript;
    private SphereCollider sphereCollider;
    private float timer;
    void Start()
    {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        healthScript = FindFirstObjectByType<Health>();
        seaMineScript = FindFirstObjectByType<SeaMine>();
        enemyHealthScript = FindFirstObjectByType<EnemyHealth>();
    }

    void Update()
    {
        if (seaMineScript.hasExploded == true)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 0.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            healthScript.health -= 35;
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {

            enemyHealthScript.health -= 90000;
        }
        else
        {

            Destroy(other.gameObject);
        }
    }
}
