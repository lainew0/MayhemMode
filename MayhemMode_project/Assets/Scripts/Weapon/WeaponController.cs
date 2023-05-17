using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon wpn;
    Character character;

    public int damage;
    float range;

    void Awake()
    {
        character = FindObjectOfType<Character>();
        
        ChangeWeaponStats();
    }


    private void ChangeWeaponStats()
    {
        range = wpn.stats.range * character.multiplier.range;
        transform.localScale *= range;
        damage = Mathf.RoundToInt(wpn.stats.damage * character.multiplier.damage);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyBehaviour enemy = collider.GetComponent<EnemyBehaviour>();
        if (enemy != null)
        {
            Debug.Log($"{enemy.name}  was taking {damage} by {wpn.weaponName}");
            enemy.TakeDamage(damage);
        }
    }
}
