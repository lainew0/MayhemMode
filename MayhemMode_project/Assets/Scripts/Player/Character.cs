using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Character : MonoBehaviour, IDamagable
{
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


#region Actions/Events
    public static Action<int> onHealthChanged;
    public static Action<int> onExpChanged;
    public static Action<int> onKillCountChanged;

#endregion


    void Start()
    {
        currentHealth = maxHealth;
        onHealthChanged?.Invoke(currentHealth);

        EnemyBehaviour.onEnemyDied += Kill;
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
    }

    void HandleKnockback(GameObject obj)
    {
        RaycastHit hit;
        
    }

    public void TakeDamage(int damage)
    {
        // Добавить Raycast для кнокбэка ближайших врагов
        currentHealth -= damage;
        onHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0) Die();
    }

    void GatherExp()
    {
        onExpChanged?.Invoke(exp);
    }    

    public void Die()
    {
        SceneManager.LoadScene("Main");
    }
}
