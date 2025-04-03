using UnityEngine;

public class SpeedPickup : PickupThingies
{
    [SerializeField] private float newSpeed;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickedUp = true;
            movementScript.speed = newSpeed;
            PickUp();
        }
    }
}
