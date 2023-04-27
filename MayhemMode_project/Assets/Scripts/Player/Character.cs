using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour, IDamagable
{
    public int maxHealth = 3;
    public int currentHealth;
    public int exp;
    private int killCount;

    public static Action<int> onHealthChanged;

    void Start()
    {
        currentHealth = maxHealth;
        onHealthChanged?.Invoke(currentHealth);
    }

    void Update()
    {

    }

    void BaseAttack()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        onHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0) Die();
    }

    void GatherExp()
    {
        
    }    

    public void Die()
    {
        Application.Quit();
    }
}
