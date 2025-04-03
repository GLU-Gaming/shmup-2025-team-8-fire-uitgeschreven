using UnityEngine;

public class Shoot : MonoBehaviour
{
    //projectiles and spawnpoints
    [SerializeField] private GameObject bullet1;
    [SerializeField] private GameObject harpoon1;
    [SerializeField] private GameObject bulletSpawnPoint;
    [SerializeField] private GameObject harpoonSpawnPoint;

    private GameObject bullet2;
    private GameObject harpoon2;

    //projectile rigidbody
    private Rigidbody bulletBody;
    private Rigidbody harpoonBody;

    private WeaponSwitcher weaponSwitcher;
    //projectile speed and current weapon
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float harpoonSpeed;
    [SerializeField] private float bulletShootCooldown;
    [SerializeField] private float harpoonShootCooldown;
    private float currentWeapon = 0;
    //timer
    private float timer;
    private float weaponTimer;

    private void Start()
    {
        weaponSwitcher = FindFirstObjectByType<WeaponSwitcher>();
    }
    void FixedUpdate()
    {
        //increase the timer each frame
        timer += Time.deltaTime;
        weaponTimer += Time.deltaTime;

        //swap weapon
        if (Input.GetKey(KeyCode.Q))
        {
            //change the current weapon value
            if (weaponTimer >= 1f)
            {
                if (currentWeapon == 0)
                {
                    weaponSwitcher.isHarpoonActive = false;
                    currentWeapon = 1;
                }
                else if (currentWeapon == 1)
                {
                    weaponSwitcher.isHarpoonActive = true;
                    currentWeapon = 0;
                }

                print(currentWeapon);
            }
            weaponTimer = 0;
        }
        //is the shoot buttin pressed
        if (Input.GetKey("space"))
        {
            //regular bullet
            if (currentWeapon == 0)
            {
                //bullet cooldown
                if (timer >= bulletShootCooldown)
                {
                    shootWeapon(bullet1, bullet2, bulletBody, bulletSpawnPoint, bulletSpeed);
                }
            }
            //harpoon
            else if (currentWeapon == 1)
            {
                //harpoon cooldown
                if (timer >= harpoonShootCooldown)
                {
                    shootWeapon(harpoon1, harpoon2, harpoonBody, harpoonSpawnPoint, harpoonSpeed);
                }
            }
        }
    }
    //function to fire the projectiles
    private void shootWeapon(GameObject weaponPrefab, GameObject newWeapon, Rigidbody rigidbody, GameObject spawnpoint, float projectileSpeed)
    {
        newWeapon = Instantiate(weaponPrefab, spawnpoint.transform.position, spawnpoint.transform.rotation);
        rigidbody = newWeapon.GetComponent<Rigidbody>();
        rigidbody.AddForce(newWeapon.transform.forward * projectileSpeed);
        //reset timer
        timer = 0;
    }
}
