using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Weapon weapon;
    float cooldownTime;
    float activeTime;

    enum WeaponState
    {
        ready,
        cooldown,
        active,
    }
    WeaponState state = WeaponState.cooldown;


    void Update()
    {
        switch (state)
        {
            case WeaponState.ready:
                weapon.Activate();
                state = WeaponState.active;
                activeTime = weapon.activeTime;
            break;
            case WeaponState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                } else
                {
                    state = WeaponState.cooldown;
                    cooldownTime = weapon.cooldownTime;
                }
            break;
            case WeaponState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                } else
                {
                    state = WeaponState.ready;
                }
            break;
        }
    }
}
