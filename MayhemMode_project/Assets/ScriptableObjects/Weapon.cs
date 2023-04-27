using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float cooldownTime;
    public float activeTime;

    public virtual void Activate() {}
}
