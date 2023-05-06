using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeAttackWeapon", menuName = "ScriptableObjects/Weapon/RangeAttack")]
public class RangeAttack : Weapon
{
    [HideInInspector]
    public float speed;
    private GameObject obj;

    public override void Spawn(GameObject parent, Transform weaponPoint)
    {   
        Vector3 dir = Input.mousePosition;

        GameObject bullet = Instantiate(weaponPrefab, weaponPoint.position, Quaternion.identity);

        bullet.transform.rotation = Quaternion.LookRotation(dir);

        bullet.GetComponent<Rigidbody2D>().AddForce(dir * 500);
        Destroy(bullet, 2f);
    }
}
