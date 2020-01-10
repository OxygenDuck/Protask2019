using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Helper
{
    //Resources folder locations
    private const string AttackSprites =    "Sprites/Enemies/Attack/";
    private const string IdleSprites =      "Sprites/Enemies/Idle/";
    private const string AttackAnimation =  "Animation/Enemies/Attack/";
    private const string IdleAnimation =    "Animation/Enemies/Idle/";

    //Get enemy sprites
    public static EnemySprites EnemyGetSpritesByName(string name)
    {
        EnemySprites sprites = new EnemySprites
        {
            Attack = Resources.LoadAll<Sprite>(AttackSprites + name),
            Idle = Resources.LoadAll<Sprite>(IdleSprites + name),
            AttackAnim = Resources.Load<Animation>(AttackAnimation + name),
            IdleAnim = Resources.Load<Animation>(IdleAnimation + name)
        };

        return sprites;
    }

    //Play audio
    public static void PlayAudio(string source)
    {
        AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Audio/" + source), new Vector3(0,0));
    }
}