using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public enum Type
    {
        Grass,
        Sand,
        Water,
        Void
    } 
    public Type type;

    public Tile(Type type)
    {
        this.type = type;
    }

    public void SetTile(Type newType)
    {
        type = newType;
    }
}
