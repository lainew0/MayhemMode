using UnityEngine;

[CreateAssetMenu(fileName = "MeleeAttackWeapon", menuName = "ScriptableObjects/Weapon/MeleeAttack")]
public class MeleeAttack : Weapon
{
    private GameObject obj;

    public override void Spawn(GameObject parent, Transform weaponPoint)
    {
        obj = Instantiate(weaponPrefab, weaponPoint.position, weaponPoint.rotation, parent.transform);
        Destroy(obj, activeTime);
    }
}
