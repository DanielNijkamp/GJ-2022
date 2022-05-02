using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
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
}
