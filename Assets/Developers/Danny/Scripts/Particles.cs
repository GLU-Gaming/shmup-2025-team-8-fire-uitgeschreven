using UnityEngine;

public class Particles : MonoBehaviour
{
    private float timer;
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
