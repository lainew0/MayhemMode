using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public List<Weapon> weaponList;
    float activeTime;
    public Transform weaponPoint;
    float[] wpnCooldownTime;

    void Start()
    {
        wpnCooldownTime = new float[weaponList.Count-1];
    }

    void Update()
    {
        CalculatePosition();
    }

    void CalculatePosition()
    {
        Vector2 weaponPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - weaponPosition;
        transform.right = direction;
    }

    void Setup()
    {
        for (int i = 0; i < weaponList.Count - 1; i++)
        {
            float cooldownTime = weaponList[i]._cooldownTime;
            {
                switch (weaponList[i].state)
                {
                    case WeaponState.ready:
                        {
                            Debug.Log(weaponList[i].name);
                            weaponList[i].Spawn(gameObject, weaponPoint);
                            weaponList[i].state = WeaponState.cooldown;
                        }
                        break;
                    case WeaponState.cooldown:
                        if (cooldownTime > 0)
                        {
                            cooldownTime -= Time.deltaTime;
                        }
                        else
                        {
                            weaponList[i].state = WeaponState.ready;
                        }
                        break;
                }
            }
        }
    }
}
