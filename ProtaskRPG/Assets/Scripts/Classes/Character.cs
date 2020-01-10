using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Stats stats = new Stats();

    //Looks
    public EnemySprites sprites; //TODO: Rework this to use player sprites when they are made
    public Color[] colors = new Color[] { new Color(1, 1, 1), new Color(1, 1, 1), new Color(1, 1, 1)}; //Saves the chosen colours for the character

    public ushort health; //the current health

    //Execute before first frame
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

    //Set sprite
    public void SetSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites.Idle[0];
    }

    //Set Colors
    public void SetColors(Color head, Color body, Color legs)
    {
        colors[0] = head;
        colors[1] = body;
        colors[2] = legs;
    }
}
