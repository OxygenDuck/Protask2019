using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Collision handler
public class collision : MonoBehaviour
{
    //The battle controller to call
    GameObject battleController;

    //Collision handling
    public void OnCollisionEnter2D(Collision2D collisionAdee)
    {
        battleController = GameObject.Find("BattleController");
        battleController.GetComponent<BattleSystem>().StartBattle();
    }
}
