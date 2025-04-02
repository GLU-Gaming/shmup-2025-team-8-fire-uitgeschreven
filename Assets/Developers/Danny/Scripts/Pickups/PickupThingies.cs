using UnityEngine;

public class PickupThingies : MonoBehaviour
{
    protected Health healthScript;
    protected PlayerMovement movementScript;
    protected Shoot shootScript;


    protected bool pickedUp = false;
    private void Start()
    {
        healthScript = FindAnyObjectByType<Health>();
        movementScript = FindFirstObjectByType<PlayerMovement>();
        shootScript = FindFirstObjectByType<Shoot>();
    }
    virtual protected void PickUp()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            pickedUp = true;
            PickUp();

        }
    }
}
