using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] GameObject harpoon;
    [SerializeField] GameObject minigun;
    public bool isHarpoonActive = false;

    void Update()
    {
        if (isHarpoonActive == true)
        {
            harpoon.SetActive(false);
            minigun.SetActive(true);
        }
        else
        {
            harpoon.SetActive(true);
            minigun.SetActive(false);
        }
    }
}
