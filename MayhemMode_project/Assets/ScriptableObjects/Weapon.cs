using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/BaseWeapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public float cooldownTime;
    public float activeTime;
    public float damage;
    public float range;
    public float areaEffect;
    public float knockbackPower;

    public virtual void Activate() {}
}
