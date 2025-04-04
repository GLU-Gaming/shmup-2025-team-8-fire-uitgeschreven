using UnityEngine;

public class SpeedPickup : PickupThingies
{
    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("ProjectilesHarpoon"))
        {
            pickedUp = true;


            shootScript.lowerCooldown = true;


            PickUp();
        }
    }


}
