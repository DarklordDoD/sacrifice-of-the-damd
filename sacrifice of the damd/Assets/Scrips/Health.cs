using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    
    [SerializeField]
    int maxHealth;
    [SerializeField]
    float invincibilityTime;

    float invincibility;
    [SerializeField]
    int currentHealth;

    [SerializeField]
    GameObject sceneManeger;
    SceneManeger deathDetect;

    [Header("Health Bar")]
    [SerializeField]
    bool hasHealthBar;
    [SerializeField]
    GameObject healthBar;
    HealthBar healthIndikator;

    // Start is called before the first frame update
    void Start()
    {       
        invincibility = invincibilityTime;
        currentHealth = maxHealth;
        if (hasHealthBar)
        {
            healthIndikator = healthBar.GetComponent<HealthBar>();
            healthIndikator.SetMaxHealth(maxHealth);
            healthIndikator.SetHealth(currentHealth);
        }
        if (sceneManeger != null)
        {
            deathDetect = sceneManeger.GetComponent<SceneManeger>();
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
                healthIndikator.SetHealth(currentHealth);
            }

            if (currentHealth <= 0)
            {            
                if (sceneManeger != null)
                {
                    deathDetect.RestartLevel();
                }
                Destroy(gameObject);
            }
        }
    }
}
