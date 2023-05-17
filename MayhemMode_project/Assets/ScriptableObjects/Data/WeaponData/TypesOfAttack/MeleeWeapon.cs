using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeapon", menuName = "ScriptableObjects/Weapons/MeleeWeapon")]
public class MeleeWeapon : Weapon
{
    public override void ActivateAbility(Transform spawnPoint)
    {
        if (canUseAbility)
        {
            GameObject obj = Instantiate(weaponPrefab, spawnPoint.position, spawnPoint.rotation, spawnPoint);
            Destroy(obj, stats.duration);
        }
    }
}
