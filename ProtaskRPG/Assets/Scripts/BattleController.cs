using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private Transform pfCharacterBattle;

    private void Start()
    {
        SpawnCharacter(false);
        SpawnCharacter(true);
    }

    private void SpawnCharacter(bool IsPlayerTeam)
    {
        Vector3 position;
        if (IsPlayerTeam)
        {
            position = new Vector3(-5, 0);

        }
        else
        {
            position = new Vector3(5, 0);
        }
        GameObject character = Instantiate(pfCharacterBattle, position, Quaternion.identity).gameObject;
        if (IsPlayerTeam)
        {
            character.GetComponent<SpriteRenderer>().color = Color.green;
        }
        
    }
}
