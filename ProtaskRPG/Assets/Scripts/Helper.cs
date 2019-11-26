using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Helper
{
    private const string AttackSprites =    "Sprites/Enemies/Attack/";
    private const string IdleSprites =      "Sprites/Enemies/Idle/";
    private const string AttackAnimation =  "Animation/Enemies/Attack/";
    private const string IdleAnimation =    "Animation/Enemies/Idle/";

    public static EnemySprites EnemyGetSpritesByName(string name)
    {
        EnemySprites sprites = new EnemySprites();
        sprites.Attack = Resources.LoadAll<Sprite>(AttackSprites + name);
        sprites.Idle = Resources.LoadAll<Sprite>(IdleSprites + name);
        sprites.AttackAnim = Resources.Load<Animation>(AttackAnimation + name);
        sprites.IdleAnim = Resources.Load<Animation>(IdleAnimation + name);

        return sprites;
    }
}