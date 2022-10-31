using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Slider healthSlider;
    [SerializeField]
    GameObject healthIndikator;
    [SerializeField]
    float healthOplooftetI = 1;

    private void Start()
    {
        healthSlider = this.GetComponent<Slider>();
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = Mathf.Pow(maxHealth, healthOplooftetI);
    }

    public void SetHealth(int health)
    {
        healthSlider.value = Mathf.Pow(health, healthOplooftetI);
        
        if (health <= 0)
        {
            healthIndikator.SetActive(false);
        }
    }

}
