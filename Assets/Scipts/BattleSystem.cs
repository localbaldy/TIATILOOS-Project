using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, WAITING }
public class BattleSystem : MonoBehaviour
{

    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;

    public Transform PlayerBattleStation;
    public Transform EnemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    Animator enemyAnim;
    Animator playerAnim;

    public HealthBar PlayerHealthBar;
    public HealthBar EnemyHealthBar;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.5f;
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {

        GameObject playerGO = Instantiate(PlayerPrefab, PlayerBattleStation.transform.position, quaternion.identity);
        playerUnit = playerGO.GetComponent<Unit>();
        playerAnim = playerGO.GetComponent<Animator>();

        GameObject enemyGO = Instantiate(EnemyPrefab, EnemyBattleStation.transform.position, quaternion.identity);
        enemyUnit = enemyGO.GetComponent<Unit>();
        enemyAnim = enemyGO.GetComponent<Animator>();

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }

    IEnumerator PlayerAttack()
    {

        playerAnim.SetTrigger("Attack1");

        state = BattleState.WAITING;

        bool isDead = enemyUnit.TakeDamage(playerUnit.Damage);

        EnemyHealthBar.DrawHearts();

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            enemyAnim.SetTrigger("die");
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    void EndBattle()
    {
        print("end");
    }

    IEnumerator EnemyTurn()
    {

        enemyAnim.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.Damage);

        PlayerHealthBar.DrawHearts();

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void PlayerTurn()
    {

        print("playertunr");

    }

    public void OnAttackButton()
    {
        
        if (state != BattleState.PLAYERTURN)
            return;
        print("hej");
        StartCoroutine(PlayerAttack());

    }
}
