using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMultiplier : Character
{

// Multipliers allow players to optimize his own build
#region Multipliers_Var
        
    public float damage_Multiplier;
    public float speed_Multiplier;
    public float cooldownTime__Multiplier;
    public float activeTime_Multiplier;
    public float range_Multiplier;
    public float areaEffect_Multiplier;
    public float knockback_Multiplier;
    public float souls_Multiplier;
    public float exp_Multiplier;

#endregion
}
