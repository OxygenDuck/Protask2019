using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    GameObject battleController;
    public void OnCollisionEnter2D(Collision2D collisionAdee)
    {
        battleController = GameObject.Find("BattleController");
        battleController.GetComponent<BattleSystem>().StartBattle();
    }
}
