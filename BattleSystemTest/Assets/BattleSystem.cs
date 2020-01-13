using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

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
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject PlayerObject = Instantiate(PlayerPrefab, new Vector3(-5, 0), new Quaternion());
        PlayerUnit = PlayerObject.GetComponent<Unit>();
        PlayerHUD.SetHUD(PlayerUnit);

        GameObject EnemyObject = Instantiate(EnemyPrefab, new Vector3(5, 0), new Quaternion());
        EnemyUnit = EnemyObject.GetComponent<Unit>();
        EnemyHUD.SetHUD(EnemyUnit);

        DialogueText.text = "A wild " + EnemyUnit.unitName + " has appeared!";
    }
}
