using UnityEngine;

public class PickupThingies : MonoBehaviour
{
    protected Health healthScript;
    protected PlayerMovement movementScript;
    protected Shoot shootScript;
    private void Start()
    {
        healthScript = FindAnyObjectByType<Health>();
        movementScript = FindFirstObjectByType<PlayerMovement>();
        shootScript = FindFirstObjectByType<Shoot>();
    }
    protected virtual void Skibidi()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Skibidi();
    }
}
