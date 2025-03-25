using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] public float health;
    void Start()
    {
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }
    private void Update()
    {
        healthBar.fillAmount = health / 100f;
    }
}
