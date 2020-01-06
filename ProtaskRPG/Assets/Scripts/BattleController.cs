using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private EncounterData encounterData;

    private void Start()
    {
        //Set enemies
        //TODO: Debug: get encounterdata from controller object, later it should be received from enemies in the overworld
        encounterData = gameObject.GetComponent<EncounterData>();

        for (int i = 0; i < encounterData.Enemies.Count; i++)
        {
            GameObject enemy = Instantiate(Resources.Load<GameObject>("Prefabs/BattleEnemy"), new Vector3(1,-i,0), new Quaternion());
            //enemy.GetComponent<SpriteRenderer>().sprite = null;
            //enemy.SetActive(false);
            //enemy.GetComponent<Enemy>() = encounterData.Enemies[i];
        }

        //Set Players

        //DEBUG: Set a single player
        //encounterData.Characters.Add(new Character());
        //encounterData.Characters[0].SetAnimations("crab");

        //for (int i = 0; i < encounterData.Characters.Count; i++)
        //{
        //    GameObject character = Instantiate(Resources.Load<GameObject>("Prefabs/BattleCharacter"), new Vector3(-1, -i, 0), new Quaternion());
        //}
        
        //Set first round, determine turn order
    }

    //Set round
}
