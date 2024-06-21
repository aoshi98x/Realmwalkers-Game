using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBattleManager : MonoBehaviour
{
    public static DataBattleManager Instance {get; private set;}
    public Sprite PlayerSprite { get => playerSprite; set => playerSprite = value; }
    public CharacterStats PlayerStats { get => playerStats; set => playerStats = value; }
    public EnemyStats ActualEnemyStats { get => actualEnemyStats; set => actualEnemyStats = value; }

    [Header("Player Variables")]
    Sprite playerSprite;
    CharacterStats playerStats;

    [Header("Enemy Variables")]
    EnemyStats actualEnemyStats;
    
     private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public Sprite EnemySprite()
    {
        SpriteRenderer enemy = GameObject.FindWithTag("Enemy").GetComponent<SpriteRenderer>();
        return enemy.sprite;
    }
    void GiveExperience(CharacterStats player, EnemyStats enemy) 
    {
        player.experiencePoints += enemy.experienceDelivered;
    }
    

    public void CheckRewards()
    {
        if(ActualEnemyStats.isDungeonCreature)
        {
            //ClaimReward
            GiveExperience(PlayerStats, ActualEnemyStats);
        }
        else
        {
            GiveExperience(PlayerStats, ActualEnemyStats);
        }
    }
}
