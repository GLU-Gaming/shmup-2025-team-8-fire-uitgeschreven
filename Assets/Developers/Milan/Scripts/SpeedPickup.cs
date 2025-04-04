using UnityEngine;

public class SpeedPickup : PickupThingies
{
    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickedUp = true;


            shootScript.lowerCooldown = true;


            PickUp();
        }
    }


}
