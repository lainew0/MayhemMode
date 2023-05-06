using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Character : MonoBehaviour, IDamagable
{
    public Multiplier multiplier;

#region Public_Variables
    public int maxHealth = 50;
    public float speed = 5f;
    public int currentHealth;
    public int exp = 0;
    
#endregion

#region Private_Variables
    private int killCount = 0;
    private float invinciblityTime = 1f;

#endregion

    void Start()
    {
        maxHealth = Mathf.RoundToInt(maxHealth * multiplier.health);
        currentHealth = maxHealth;
        ActionsManager.onHealthChanged?.Invoke(currentHealth);

        ActionsManager.onEnemyDied += Kill;
    }

    void Update()
    {

    }

    void BaseAttack()
    {
        
    }

    void Kill()
    {
        killCount++;
        ActionsManager.onKillCountChanged?.Invoke(killCount);
    }

    public void TakeDamage(int damage)
    {
        // Добавить Raycast для кнокбэка ближайших врагов
        currentHealth -= damage;
        ActionsManager.onHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0) Die();
    }

    void GatherExp()
    {
        ActionsManager.onExpChanged?.Invoke(exp);
    }    

    public void Die()
    {
        SceneManager.LoadScene("Main");
    }
}
