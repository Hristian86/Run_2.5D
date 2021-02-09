using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBarScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int maxHealth)
    {
        this.slider.maxValue = maxHealth;
        this.slider.maxValue = maxHealth;

        this.fill.color = this.gradient.Evaluate(1f);

    }

    public void SetHealth(int health)
    {
        this.slider.value = health;

        this.fill.color = gradient.Evaluate(this.slider.normalizedValue);
    }
}
