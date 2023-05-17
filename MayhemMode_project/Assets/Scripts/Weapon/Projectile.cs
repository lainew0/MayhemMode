using UnityEngine;

public class Projectile : WeaponController
{
    [SerializeField] int penetrationCount = 2;
    void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyBehaviour enemy = collider.GetComponent<EnemyBehaviour>();
        if (enemy != null)
        {
            Debug.Log($"{enemy.name}  was taking {damage} by {wpn.weaponName}");
            enemy.TakeDamage(damage);

            penetrationCount--;

            if (penetrationCount <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}