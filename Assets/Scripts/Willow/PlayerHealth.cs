using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public float maxHealth;
    public Slider slider;
    public Image popUp;

    void Start()
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }
    void Update()
    {
        slider.value = currentHealth;

        if (currentHealth >= 3)
        {
            popUp.gameObject.SetActive(true);
        }
        else if (currentHealth < 3)
        {
            popUp.gameObject.SetActive(false);
        }
    }
    public void ChangeHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
