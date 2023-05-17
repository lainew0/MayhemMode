using UnityEngine;

[CreateAssetMenu(fileName = "RangeWeapon", menuName = "ScriptableObjects/Weapons/RangeWeapon")]
public class RangeWeapon : Weapon
{
    public float speed;

    public override void ActivateAbility(Transform spawnPoint)
    {
        if (canUseAbility)
        {
            GameObject projectile = Instantiate(weaponPrefab, spawnPoint.position, spawnPoint.rotation); // Spawn the projectile at the spawn point
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>(); // Get the Rigidbody component of the projectile
            rb.velocity = projectile.transform.right * speed;
            Destroy(projectile, stats.duration);
        }
    }
}
