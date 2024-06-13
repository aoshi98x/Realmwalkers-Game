using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "BattleStats/NewWeaponStats", order = 1)]
public class WeaponStats : ScriptableObject
{
    public int maxDamage;
    public int minDamage;
    public int wear;
    public int maxWear;

}
