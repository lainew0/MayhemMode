using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamagable
{
    public int maxHealth = 3;
    public int currentHealth;
    public int exp;
    private int killCount;


    public event OnHealthChanged onHealthChanged;
    public event OnExpChanged onExpChanged; 
    public event OnKillCountChanged onKillCountChanged;
    public delegate void OnHealthChanged(int health);
    public delegate void OnExpChanged(int exp);
    public delegate void OnKillCountChanged(int killCount);

    void Awake()
    {
        currentHealth = 3;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Die();
    }

    public void Die()
    {
        Application.Quit();
    }
}
