using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Battle state enum
public enum BattleState { NONE, START, PLAYERTURN, ENEMYTURN, WON, LOST, RAN }

//Battle system handler
public class BattleSystem : MonoBehaviour
{
    public BattleState state; //The current battle state

    public GameObject battleCanvas; //The canvas object of the battle UI

    //Character positions in the canvas
    public GameObject PlayerPosition; 
    public GameObject EnemyPosition;

    //Player and enemy objects
    GameObject Player;
    GameObject EnemyPrefab;

    //Unit classes in the player and enemy objects
    Unit PlayerUnit;
    Unit EnemyUnit;

    //text in the dialogue
    public Text DialogueText;

    //References to the HUD display for the player and enemy
    public BattleHUD PlayerHUD;
    public BattleHUD EnemyHUD;

    //On start, nothing takes place
    void Start()
    {
        state = BattleState.NONE;
    }

    //Start a battle
    public void StartBattle()
    {
        Player = GameObject.Find("Player");
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        battleCanvas.SetActive(true);
        WorldController.worldstate = Worldstate.BATTLE;
    }

    //Setup of the battle
    IEnumerator SetupBattle()
    {
        GameObject PlayerSprite = Instantiate(Resources.Load<GameObject>("Prefabs/BattleCharacter"), PlayerPosition.transform);
        PlayerSprite.transform.SetParent(PlayerPosition.transform);
        PlayerUnit = Player.GetComponent<Unit>();
        PlayerHUD.SetHUD(PlayerUnit);

        for (int i = 0; i < 3; i++)
        {
            GameObject sprite = Instantiate(Resources.Load<GameObject>("Prefabs/SpriteObject"), PlayerSprite.transform);
            sprite.transform.SetParent(PlayerSprite.transform);
            switch (i)
            {
                case 0: sprite.GetComponent<SpriteObject>().SetSprite("Character/Battle/battleHead"); break;
                case 1: sprite.GetComponent<SpriteObject>().SetSprite("Character/Battle/battleBody"); break;
                case 2: sprite.GetComponent<SpriteObject>().SetSprite("Character/Battle/battleLegs"); break;
            }
            sprite.GetComponent<SpriteObject>().SetColor(WorldController.CharacterColors[i]);
        }

        int enemyType = new System.Random().Next(0,2);
        EnemyPrefab = Resources.Load<GameObject>("Prefabs/BattleEnemy" + enemyType.ToString());
        GameObject EnemyObject = Instantiate(EnemyPrefab, EnemyPosition.transform);
        EnemyObject.transform.SetParent(EnemyPosition.transform);
        EnemyUnit = EnemyObject.GetComponent<Unit>();
        EnemyHUD.SetHUD(EnemyUnit);

        DialogueText.text = "A wild " + EnemyUnit.unitName + " has appeared!";

        yield return new WaitForSeconds(2f);

        
        PlayerTurn();
    }

    //Player turn
    void PlayerTurn()
    {
        state = BattleState.PLAYERTURN;
        DialogueText.text = "What will " + PlayerUnit.unitName + " do?";
    }

    //Attack
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

    //Enemy Turn
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

    //Healing
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

    //Running
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

    //ending a battle
    public void EndBattle()
    {
        switch (state)
        {            
            case BattleState.WON:
                //SHOW PLAYER WON
                StartCoroutine(ShowEndscreen());
                break;
            case BattleState.LOST:
                //SHOW PLAYER LOST
                StartCoroutine(ShowEndscreen());

                PlayerUnit.currentHp = PlayerUnit.maxHp;
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

        ExitBattle();
    }

    //Exit a battle
    void ExitBattle()
    {
        state = BattleState.NONE;
        battleCanvas.SetActive(false);

        //TODO:Resume movement
        WorldController.worldstate = Worldstate.MOVE;
    }

}
