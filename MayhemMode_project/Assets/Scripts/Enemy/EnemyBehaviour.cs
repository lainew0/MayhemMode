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
    }

    void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        //rb.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameobject)
        {
            Attack();
        }
    }

    void Attack()
    {
        //targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        //health -= damage;
        //if (health <= 0) Die();
    }

    public void Die()
    {
        onEnemyDied?.Invoke();
        Destroy(gameObject);
    }
}
