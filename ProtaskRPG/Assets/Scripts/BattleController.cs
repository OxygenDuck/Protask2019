using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private EncounterData encounterData;

    private void Start()
    {
        //Set enemies
        //DEBUG: JUST SPAWN 2 CRABS
        encounterData = new EncounterData();
        encounterData.Enemies.Add(new Crab());
        encounterData.Enemies.Add(new Crab());

        for (int i = 0; i < encounterData.Enemies.Count; i++)
        {
            GameObject enemy = Instantiate(Resources.Load<GameObject>("Prefabs/BattleEnemy"), new Vector3(0,i * 2,0), new Quaternion());
            enemy.GetComponent<EnemyBehavior>().enemyClass = encounterData.Enemies[i];
            enemy.GetComponent<EnemyBehavior>().SetSprite();
        }
        //Set Players


        //Set first round, determine turn order
    }

    //Set round
}
