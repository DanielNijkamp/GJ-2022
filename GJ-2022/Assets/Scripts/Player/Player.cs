using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{

    private bool hasDied = false;
    public float BaseHealth;
    public float CurrentHealth;

    public float BaseShield;
    public float CurrentShield;

    public Slider HealthSlider;
    public Slider ShieldSlider;

    public TextMeshProUGUI Health_Text;
    public TextMeshProUGUI Shield_Text;

    private Vector3 startingpos;
    private Quaternion startingrot;

    private void Update()
    {
        if (CurrentHealth <= 0 && !hasDied)
        {
            Die();
            hasDied = true;
        }
    }
    public void ResetPosition()
    {
        transform.position = startingpos;
        transform.rotation = startingrot;
    }
    private void Awake()
    {
        startingpos = transform.position;
        startingrot = transform.rotation;

        CurrentHealth = BaseHealth;
        CurrentShield = BaseShield;

        HealthSlider.value = BaseHealth;
        ShieldSlider.value = BaseShield;

        HealthSlider.maxValue = BaseHealth;
        ShieldSlider.maxValue = BaseShield;
    }

    private void OnGUI()
    {
        HealthSlider.value = CurrentHealth;
        ShieldSlider.value = CurrentShield;

        Health_Text.text = "Health : " + HealthSlider.value;
        Shield_Text.text = "Shield : " + ShieldSlider.value;
    }
    public void DamagePlayer(float amount)
    {
        if (CurrentShield != 0 || CurrentShield > 0) // check if player still has shield
        {
            if (CheckShield(amount))
            {
                CurrentShield -= amount;
                return;
            }
            else 
            {
                Tuple<float, float> tuple = CalculateDamage(amount);
                CurrentHealth -= tuple.Item1;
                CurrentShield -= tuple.Item2;
                return;
            }

        }
        else
        {
            CurrentHealth -= amount;
        }
    }
    private bool CheckShield(float amount) // check if the amount will put the shield amount in the negative
    {
        float new_amount = CurrentShield - amount; // 100 - 20
        if (new_amount >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private Tuple<float, float> CalculateDamage(float amount)
    {
        float a = CurrentHealth + CurrentShield;
        float b = a - amount;

        float result1 = Mathf.Abs(b - 100);
        float result2 = a - CurrentHealth;

        return Tuple.Create(result1, result2);
    }
    private void Die()
    {
        print("Player has died");
        FindObjectOfType<GameManager>().SlowDownTime();
    }
    
}
 


