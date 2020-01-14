using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public int strength;
    public int maxHp;
    public int currentHp;

    public bool TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            return true;
        }

        return false;
    }

    public int GetCurrentHP()
    {
        if (currentHp < 0)
        {
            return 0;
        }

        return currentHp;
    }

    public void Heal()
    {
        currentHp += strength;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }
}
