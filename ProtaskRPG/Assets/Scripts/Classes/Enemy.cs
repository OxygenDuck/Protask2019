using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deprecated Enemy class
public class Enemy : MonoBehaviour
{
    public Stats stats = new Stats();
    public EnemySprites sprites;

    public string enemyName = "";
    ushort health;

    void Start()
    {
        stats.level = 5;
        stats.Randomize();
        health = stats.MaxHealth;
        SetAnimations(enemyName);
    }

    public void SetAnimations(string name)
    {
        sprites = Helper.EnemyGetSpritesByName(name);
    }
}

public class EnemySprites
{
    public Sprite[] Attack = null;
    public Sprite[] Idle = null;
    public Animation AttackAnim = null;
    public Animation IdleAnim = null;
}