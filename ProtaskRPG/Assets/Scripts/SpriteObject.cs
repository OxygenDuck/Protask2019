﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteObject : MonoBehaviour
{
    //Set sprite
    public void SetSprite(string path)
    {
        string fullPath = "Sprites/" + path;
        Debug.Log(Resources.Load<Sprite>(fullPath));
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(fullPath);
    }

    //Set sprite color
    public void SetColor(Color color)
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
}
