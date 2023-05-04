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

    public static Action onEnemyDied;

    void Awake()
    {
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
        rb.velocity = direction * enemyConfiguration.speed;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
        enemyConfiguration.health -= damage;
        if (enemyConfiguration.health <= 0) Die();
    }

    public void Die()
    {
        onEnemyDied?.Invoke();
        Destroy(gameObject);
    }
}
