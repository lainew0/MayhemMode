using System;
using UnityEngine;

[Serializable]
public class WeaponStats
{
    public float abilityCooldown;
    public int damage;
    public float duration;
    public float range;
    public float areaEffect;
    public float knockbackPower;
}

public enum WeaponAbilityState {
    Ready,
    Cooldown
}

public abstract class Weapon : ScriptableObject 
{
    public string weaponName;
    public WeaponStats stats;
    public bool canUseAbility = true;
    public GameObject weaponPrefab;

    private float shootTimer = 0f;
    private float abilityTimer = 0f;
    private WeaponAbilityState abilityState = WeaponAbilityState.Ready;

    public abstract void ActivateAbility(Transform spawnPoint);

    public bool CanUseAbility() {
        if (canUseAbility && abilityState == WeaponAbilityState.Ready) 
        {
            // Реализация метода использования способности

            canUseAbility = false;
            abilityTimer = 0f;
            abilityState = WeaponAbilityState.Cooldown;
            return true;
        }
        return false;
    }

    public void Update() {
        shootTimer += Time.deltaTime;
        if (abilityState == WeaponAbilityState.Cooldown) 
        {
            abilityTimer += Time.deltaTime;
            if (abilityTimer >= stats.abilityCooldown) 
            {
                abilityState = WeaponAbilityState.Ready;
                canUseAbility = true;
            }
        }
    }
}