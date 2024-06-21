using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [Header ("Info To Battle")]

    [SerializeField] Sprite enemySprite;
    public List<WeaponStats> weaponStats = new List<WeaponStats>();

    [Header ("Inteface Elements")]
    [SerializeField] Slider lifePointsPlayer;
    [SerializeField] Slider lifePointsEnemy;
   
    void Start()
    {
        /*
        enemySprite = DataBattleManager.Instance.EnemySprite();
        lifePointsPlayer.value = DataBattleManager.Instance.PlayerStats.lifePoints; 
        lifePointsEnemy.value = DataBattleManager.Instance.ActualEnemyStats.lifePoints;
        */ 
    }
}
