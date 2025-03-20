using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float health;
    void Start()
    {
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / 100f;
    }
}
