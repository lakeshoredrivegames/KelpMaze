﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stalk : MonoBehaviour, IBreakable
{
    public float currentHealth, power, toughness;
    public float maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void PerformAttack()
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Death();
    }

    void Death()
    {
        Destroy(gameObject);
    }
}

