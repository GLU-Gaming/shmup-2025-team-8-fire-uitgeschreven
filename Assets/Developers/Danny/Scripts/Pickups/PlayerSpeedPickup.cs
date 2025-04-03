using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpeedPickup : PickupThingies
{
    private float timer;
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 5 && pickedUp == true)
        {
            movementScript.speed -= 25;
            Destroy(gameObject);
        }
        print(timer);
    }
    override protected void PickUp()
    {
        movementScript.speed += 25;
        base.PickUp();
    }
}
