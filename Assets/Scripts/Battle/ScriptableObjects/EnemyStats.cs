using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "BattleStats/NewEnemyStats", order = 2)]
public class EnemyStats :  ScriptableObject
{
    public int lifePoints;
    public int experienceDelivered;
    public bool isDungeonCreature;
    
}
