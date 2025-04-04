using UnityEngine;

public class SpeedPickup : PickupThingies
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickedUp = true;


            shootScript.lowerCooldown = true;


            PickUp();
        }
    }
}
