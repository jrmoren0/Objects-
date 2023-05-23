using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float currentHealth;

    private float maxHealth;

    private float regenHealthRate;


    public float GetHealth()
    {
        return currentHealth;
    }

    public void SetHealth(float value)
    {
        currentHealth = value;
    }

    //constructor has same name as the class
    public Health(float _maxHealth, float _regenHealthRate, float _currentHealth)
    {
        currentHealth = _currentHealth;
        maxHealth = _maxHealth;
        regenHealthRate = _regenHealthRate;
    }

    public Health()
    {

    }

    public void RegenHealth()
    {
        // add health based on time
        AddHealth(regenHealthRate * Time.deltaTime);
    }

    public void AddHealth(float value)
    {
        if((currentHealth + value) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += value;
        }
    }

    public void DeductHealth(float value)
    {
        if ((currentHealth - value) < 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= value;
        }
    }

}
