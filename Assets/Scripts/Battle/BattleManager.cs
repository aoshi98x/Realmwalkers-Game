using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [Header ("Info To Battle")]
    public CharacterStats[] characterStats;
    public List<WeaponStats> weaponStats = new List<WeaponStats>();

    [Header ("Inteface Elements")]
    [SerializeField] Slider lifePointsPlayer;
    [SerializeField] Slider lifePointsEnemy;
    //
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
