using UnityEngine;

[CreateAssetMenu(fileName = "Character_Multipliers", menuName = "ScriptableObjects/CharacterMultipliers")]
public class Multiplier : ScriptableObject
{
    // Multipliers allow players to optimize his own build
    #region Multipliers_Var
    public float health;
    public float damage;
    public float speed;
    public float cooldownTime;
    public float activeTime;
    public float range;
    public float areaEffect;
    public float knockback;
    public float souls;
    public float exp;

    #endregion

}
