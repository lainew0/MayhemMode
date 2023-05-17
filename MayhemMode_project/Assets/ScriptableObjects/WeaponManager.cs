using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    public WeaponHolder weaponHolder; // Ссылка на объект WeaponHolder

    private void Update() {
        for (int i = 0; i < weaponHolder.weapons.Count; i++) { // Вызов способности и обновление всех оружий каждый кадр
            weaponHolder.weapons[i].CanUseAbility();
            weaponHolder.weapons[i].Update();
            weaponHolder.weapons[i].ActivateAbility(weaponHolder.weaponPoint); // Стрельба каждым оружием каждый кадр
        }
    }
}