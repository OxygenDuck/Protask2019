using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, RAN }

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;

    Unit PlayerUnit;
    Unit EnemyUnit;

    public Text DialogueText;

    public BattleHUD PlayerHUD;
    public BattleHUD EnemyHUD;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject PlayerObject = Instantiate(PlayerPrefab, new Vector3(-5, 0), new Quaternion());
        PlayerUnit = PlayerObject.GetComponent<Unit>();
        PlayerHUD.SetHUD(PlayerUnit);

        GameObject EnemyObject = Instantiate(EnemyPrefab, new Vector3(5, 0), new Quaternion());
        EnemyUnit = EnemyObject.GetComponent<Unit>();
        EnemyHUD.SetHUD(EnemyUnit);

        DialogueText.text = "A wild " + EnemyUnit.unitName + " has appeared!";

        yield return new WaitForSeconds(2f);

        
        PlayerTurn();
    }

    void PlayerTurn()
    {
        state = BattleState.PLAYERTURN;
        DialogueText.text = "What will " + PlayerUnit.unitName + " do?";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        DialogueText.text = PlayerUnit.unitName + " attacked the wild " + EnemyUnit.unitName + "!";

        bool defeated = EnemyUnit.TakeDamage(PlayerUnit.strength);
        EnemyHUD.HpSlider.value = EnemyUnit.GetCurrentHP();

        yield return new WaitForSeconds(2f);

        //Check if enemy defeated
        if (defeated)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        DialogueText.text = "The wild " + EnemyUnit.unitName  + " attacked " + PlayerUnit.unitName + "!";

        bool defeated = PlayerUnit.TakeDamage(EnemyUnit.strength);
        PlayerHUD.HpSlider.value = PlayerUnit.GetCurrentHP();

        yield return new WaitForSeconds(2f);

        //Check if Player defeated
        if (defeated)
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

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerHeal());
    }

    IEnumerator PlayerHeal()
    {
        DialogueText.text = PlayerUnit.unitName + " healed!";

        PlayerUnit.Heal();
        PlayerHUD.HpSlider.value = PlayerUnit.GetCurrentHP();

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnRunButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerRun());
    }

    IEnumerator PlayerRun()
    {
        DialogueText.text = PlayerUnit.unitName + " ran away safely!";

        yield return new WaitForSeconds(2f);

        state = BattleState.RAN;
        EndBattle();
    }

    public void EndBattle()
    {
        switch (state)
        {            
            case BattleState.WON:
                //SHOW PLAYER WON
                StartCoroutine(ShowEndscreen());

                ExitBattle();
                break;
            case BattleState.LOST:
                //SHOW PLAYER LOST
                StartCoroutine(ShowEndscreen());

                PlayerUnit.currentHp = PlayerUnit.maxHp;
                ExitBattle();
                break;
            case BattleState.RAN:
                //INSTANTLY END BATTLE
                ExitBattle();
                break;
            default: throw new System.Exception("The battlestate is invalid for an end condition!");
        }
    }

    IEnumerator ShowEndscreen()
    {
        if (state == BattleState.WON)
        {
            DialogueText.text = PlayerUnit.unitName + " has won the battle!";
        }
        else
        {
            DialogueText.text = "The wild " + EnemyUnit.unitName + " has defeated " + PlayerUnit.unitName + "!";
        }

        yield return new WaitForSeconds(2f);
    }

    void ExitBattle()
    {
        //TODO: Exit battle
    }

}
