using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpeedPickup : PickupThingies
{
    private float timer;
    private bool pickedUp = false;
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 10 && pickedUp == true)
        {
            movementScript.speed -= 25;
            Destroy(gameObject);
        }
    }
    override protected void PickUp()
    {
        timer = 0;
        pickedUp = true;
        movementScript.speed += 25;
        base.PickUp();
    }
}
