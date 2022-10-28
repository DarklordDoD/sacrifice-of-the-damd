using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    [SerializeField]
    int maxHealth;
    [SerializeField]
    float invincibilityTime;

    float invincibility;
    [SerializeField]
    int currentHealth;

    [Header("Health Bar")]
    [SerializeField]
    bool hasHealthBar;
    [SerializeField]
    HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {       
        invincibility = invincibilityTime;
        currentHealth = maxHealth;
        if (hasHealthBar)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);
        }
    }

    private void FixedUpdate()
    {
        if (invincibility >= 0)
        {
            invincibility -= Time.deltaTime;
        }

    }

    public void TakeDamage(int damage)
    {
        if (invincibility <= 0)
        {
            currentHealth = currentHealth - damage;         
            invincibility = invincibilityTime;
            if (hasHealthBar)
            {
                healthBar.SetHealth(currentHealth);
            }

            if (currentHealth <= 0)
            {
                Death();
            }
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
