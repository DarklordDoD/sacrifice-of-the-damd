using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]
    HealthBar healthBar;
    [SerializeField]
    int maxHealth;
    [SerializeField]
    float invincibilityTime;
    [SerializeField]
    float invincibility;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        invincibility = invincibilityTime;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
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
            healthBar.SetHealth(currentHealth);
            invincibility = invincibilityTime;
        }
    }
}
