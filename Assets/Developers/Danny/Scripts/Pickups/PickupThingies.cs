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
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("ProjectilesHarpoon"))
        {

            pickedUp = true;
            PickUp();

        }
    }
}
