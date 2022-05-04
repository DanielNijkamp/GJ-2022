using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    bool shieldRegenAllowed = true;
    public bool hasDied = false;
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


    public float fireRate = 15f;
    private float nextTimeToFire = 0f;

    public GameObject bullet;
    private GameObject playermodel;

    void Start()
    {
        playermodel = this.GetComponentInChildren<PlayerRotation>().gameObject;
        InvokeRepeating("ShieldRegeneration", 0, 0.3f);
    }
    private void Update()
    {
        if (CurrentHealth <= 0 && !hasDied)
        {
            Die();
            hasDied = true;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Fire();
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
        StartCoroutine(DisallowShieldRegenForXSeconds(3.0f));
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
    private void Fire()
    {
        Instantiate(bullet, transform.position, playermodel.transform.rotation);
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
        CancelInvoke("ShieldRegeneration");
        print("Player has died");
        GameManager manager = FindObjectOfType<GameManager>();
        manager.SlowDownTime();
        manager.DeathScreen();
    }
    private void ShieldRegeneration()
    {
        if (shieldRegenAllowed && (CurrentShield < BaseShield))
        {
            CurrentShield += 3;
        }
    }
    IEnumerator DisallowShieldRegenForXSeconds(float delay)
    {
        shieldRegenAllowed = false;
        yield return new WaitForSecondsRealtime(delay);
        shieldRegenAllowed = true;
    }
}
 


