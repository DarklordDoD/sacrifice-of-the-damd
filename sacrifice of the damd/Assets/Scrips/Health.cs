using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    [SerializeField]
    float invincibilityTime;
    [SerializeField]
    Color damageColor;
    [SerializeField]
    float damageColorTimer;
    [SerializeField]
    GameObject entetySprite;

    float invincibility;
    int currentHealth;
    SpriteRenderer objectColor;
    float colorTimer;

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
        if (sceneManeger != null)
        {
            deathDetect = sceneManeger.GetComponent<SceneManeger>();
            currentHealth = SceneManeger.playerHealth;
        }
        else
        {
            currentHealth = maxHealth;
        }

        invincibility = invincibilityTime;

        if (hasHealthBar)
        {
            healthIndikator = healthBar.GetComponent<HealthBar>();
            healthIndikator.SetMaxHealth(maxHealth);
            healthIndikator.SetHealth(currentHealth);
        }

        objectColor = entetySprite.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (invincibility >= 0)
        {
            invincibility -= Time.deltaTime;
        } 

        if (colorTimer >= 0)
        {
            colorTimer -= Time.deltaTime;
        } 
        else
        {
            objectColor.color = Color.white;
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

            if (sceneManeger != null)
            {
                SceneManeger.playerHealth = currentHealth;
            }

            if (currentHealth <= 0)
            {            
                if (sceneManeger != null)
                {
                    SceneManeger.playerHealth = maxHealth;
                    deathDetect.RestartLevel();
                }
                Destroy(gameObject);
            }
        }

        if (damage > 0)
        {
            colorTimer = damageColorTimer;
            objectColor.color = damageColor;
        }
    }
}
