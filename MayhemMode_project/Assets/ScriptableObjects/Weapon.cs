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
    public float _cooldownTime;
    public float activeTime;
    public int damage;
    public float range;
    public float areaEffect;
    public float knockbackPower;

    public float InitCooldownTime()
    {
        return _cooldownTime;
    }

    [HideInInspector]
    public WeaponState state = WeaponState.cooldown;

    public virtual void Spawn(GameObject parent, Transform weaponPoint) {}
}
