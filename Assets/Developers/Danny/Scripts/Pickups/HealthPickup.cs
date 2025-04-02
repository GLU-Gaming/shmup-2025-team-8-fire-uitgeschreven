using Unity.VisualScripting;
using UnityEngine;

public class HealthPickup : PickupThingies
{
    override protected void PickUp()
    {
        healthScript.health += 25;
        base.PickUp();
        Destroy(gameObject);
    }
}
