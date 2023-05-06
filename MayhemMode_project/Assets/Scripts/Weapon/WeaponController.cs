using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon wpn;
    Character character;

    int damage;
    float range;

    void Awake()
    {
        character = FindObjectOfType<Character>();
        
        ChangeWeaponStats();
    }


    private void ChangeWeaponStats()
    {
        range = wpn.range * character.multiplier.range;
        transform.localScale *= range;

        damage = Mathf.RoundToInt(wpn.damage * character.multiplier.damage);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyBehaviour enemy = collider.GetComponent<EnemyBehaviour>();
        if (enemy != null)
        {
            Debug.Log(enemy.name + " was taking " + damage);
            enemy.TakeDamage(damage);
        }
    }
}
