using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public List<Weapon> weaponList;
    float cooldownTime;
    float activeTime;
    public Transform weaponPoint;

    void Update()
    {
        CalculatePosition();
        foreach (Weapon weapon in weaponList)
        {
            switch (weapon.state)
            {
                case WeaponState.ready:
                        weapon.Activate(gameObject, weaponPoint);
                        weapon.state = WeaponState.active;
                        activeTime = weapon.activeTime;
                break;
                case WeaponState.active:
                    if (activeTime > 0)
                    {
                        activeTime -= Time.deltaTime;
                    } else
                    {
                        weapon.state = WeaponState.cooldown;
                        cooldownTime = weapon.cooldownTime;
                        weapon.DestroyObject();
                    }
                break;
                case WeaponState.cooldown:
                    if (cooldownTime > 0)
                    {
                        cooldownTime -= Time.deltaTime;
                    } else
                    {
                        weapon.state = WeaponState.ready;
                    }
                break;
            }
        }
    }

    void CalculatePosition()
    {
        Vector2 weaponPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - weaponPosition;
        transform.right = direction;
    }
}
