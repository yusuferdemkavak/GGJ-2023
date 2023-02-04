using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    Movement movement;
    public Slider slider;

    public GameObject staminaBar;

    void Start()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        SetStamina(movement.stamina);

        if (movement.stamina >= 149)
        {
            staminaBar.SetActive(false);
        }
        else
        {
            staminaBar.SetActive(true);
        }
    }

    public void SetStamina(float staminaValue)
    {
        staminaValue = movement.stamina;
        slider.value = staminaValue;
    }
}
