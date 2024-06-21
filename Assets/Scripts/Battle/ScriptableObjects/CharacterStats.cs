using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "BattleStats/NewCharacterStats", order = 0)]
public class CharacterStats : ScriptableObject {
    public int lifePoints;
    public int experiencePoints;
    
}
