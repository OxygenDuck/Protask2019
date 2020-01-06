using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterData : MonoBehaviour
{
    public List<Enemy> Enemies = new List<Enemy>();
    //public List<Character> Characters = new List<Character>();

    void Start()
    {
        //DEBUG: Add a crab
        Enemy crab = gameObject.AddComponent<Enemy>();
        crab.enemyName = "Crab";
        Enemies.Add(crab);
    }
}
