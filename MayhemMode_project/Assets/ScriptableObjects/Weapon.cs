using UnityEngine;

public enum WeaponState
{
        ready,
        cooldown,
        active,
}

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/BaseWeapon")]
public class Weapon : ScriptableObject
{
    public GameObject weaponPrefab;
    public string weaponName;
    public float cooldownTime;
    public float activeTime;
    public float damage;
    public float range;
    public float areaEffect;
    public float knockbackPower;

    [HideInInspector]
    public WeaponState state = WeaponState.cooldown;

    public virtual void Activate(GameObject parent, Transform weaponPoint) {}
    public virtual void DestroyObject() {}
}
