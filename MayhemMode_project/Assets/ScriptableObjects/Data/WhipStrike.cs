using UnityEngine;

[CreateAssetMenu(fileName = "WhipStrikeWeapon", menuName = "ScriptableObjects/Weapon/WhipStrike")]
public class WhipStrike : Weapon
{
    private GameObject obj;
    public override void Activate(GameObject parent, Transform weaponPoint)
    {
        Transform parentPosition = parent.GetComponent<Transform>();

        obj = Instantiate(weaponPrefab, weaponPoint.position, weaponPoint.rotation, parentPosition);
    }

    public override void DestroyObject()
    {
        Destroy(obj);
    }
}
