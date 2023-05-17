using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public List<Weapon> weapons;
    public Transform weaponPoint;

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
}