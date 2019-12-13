using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Stats stats = new Stats();

    //Looks
    public EnemySprites sprites; //TODO: Rework this to use player sprites when they are made
    public Color[] colors = new Color[] { new Color(1, 1, 1), new Color(1, 1, 1), new Color(1, 1, 1)};

    public ushort health;

    void Start()
    {
        stats.level = 5;
        stats.Randomize();
        health = stats.MaxHealth;
    }

    //TODO: Rework this to use player sprites when they are made
    public void SetAnimations(string name)
    {
        sprites = Helper.EnemyGetSpritesByName(name);
    }

    public void SetSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites.Idle[0];
    }
}
