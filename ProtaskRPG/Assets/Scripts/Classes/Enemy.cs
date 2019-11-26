using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public Stats stats = new Stats();
    public EnemySprites sprites;

    // Start is called before the first frame update
    void Start()
    {
        stats.level = 5;
        stats.Randomize();
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