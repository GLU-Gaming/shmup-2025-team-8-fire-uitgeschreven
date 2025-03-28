using Unity.VisualScripting;
using UnityEngine;

public class HealthPickup : PickupThingies
{
    void Start()
    {

    }
    void Update()
    {

    }
    override protected void Skibidi()
    {
        healthScript.health += 25;
    }
}
