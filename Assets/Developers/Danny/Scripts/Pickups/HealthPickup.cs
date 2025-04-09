using Unity.VisualScripting;
using UnityEngine;

public class HealthPickup : PickupThingies
{

    
    override protected void PickUp()
    {

        healthScript.health += 100;
        if (healthScript.health >= 300)
        {
            healthScript.health = 300
        }
        base.PickUp();
        Destroy(gameObject);
    }
}
