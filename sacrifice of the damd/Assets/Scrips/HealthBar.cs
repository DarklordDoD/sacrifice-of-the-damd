using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider healthSlider;
    [SerializeField]
    int healthOplooftetI = 1;

    private void Start()
    {
        healthSlider = this.gameObject.GetComponent<Slider>();
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = Mathf.Pow(maxHealth, healthOplooftetI);
    }

    public void SetHealth(int health)
    {
        healthSlider.value = Mathf.Pow(health, healthOplooftetI);
    }

}
