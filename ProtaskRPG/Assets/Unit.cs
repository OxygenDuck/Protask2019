using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unit class for battle participants
public class Unit : MonoBehaviour
{
    public string unitName; //Name
    public int unitLevel; //Level
    public int strength; //Attack power
    public int maxHp; //Maximum health
    public int currentHp; //Current health

    //Take damage
    public bool TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            return true;
        }

        return false;
    }

    //Get the current HP
    public int GetCurrentHP()
    {
        if (currentHp < 0)
        {
            return 0;
        }

        return currentHp;
    }

    //Heal
    public void Heal()
    {
        currentHp += strength;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }
}
