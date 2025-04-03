public class PlayerSpeedPickup : PickupThingies
{
    private float timer = 5;
    private void FixedUpdate()
    {

    }
    override protected void PickUp()
    {
        movementScript.isBoosting = true;
        base.PickUp();
    }
}
