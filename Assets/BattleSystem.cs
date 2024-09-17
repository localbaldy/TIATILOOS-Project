using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{

    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;

    public Transform PlayerBattleStation;
    public Transform EnemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        
        GameObject playerGO = Instantiate(PlayerPrefab, PlayerBattleStation.transform.position, quaternion.identity);
        playerUnit = playerGO.GetComponent<Unit>();

        Instantiate(EnemyPrefab, EnemyBattleStation.transform.position, quaternion.identity);
        enemyUnit = playerGO.GetComponent<Unit>();
        
    }

}
