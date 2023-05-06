using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBehaviour : MonoBehaviour, IDamagable
{
    [SerializeField] Enemy enemyConfiguration;
    Character targetCharacter;
    Transform targetDestination;
    GameObject targetGameobject;
    Rigidbody2D rb;

    // Changable vars
    public int health;
    public float speed;


    void Awake()
    {
        health = enemyConfiguration.health;
        speed = enemyConfiguration.speed;

        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameobject = target;
        targetDestination = target.transform;
        targetCharacter = target.GetComponent<Character>();
    }

    void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        //rb.velocity = direction * enemyConfiguration.speed;

        rb.velocity = direction * speed;
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        //if (collider.gameObject.tag == "Weapon") return;

        if (collider.gameObject == targetGameobject)
        {
            Attack();
        }
    }

    void Attack()
    {
        targetCharacter.TakeDamage(enemyConfiguration.damage);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Die();
    }

    public void Die()
    {
        ActionsManager.onEnemyDied?.Invoke();
        Destroy(gameObject);
    }
}
