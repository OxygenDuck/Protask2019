using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public enum Type
    {
        //list of the types of materials of the map
        Grass,
        Sand,
        Water,
        Void
    } 
    public Type typeAdee;

    //constructor
    public Tile(Type a_typeAdee)
    {
        this.typeAdee = a_typeAdee;
    }

    //setting the tile to the type
    public void SetTile(Type newTypeAdee)
    {
        typeAdee = newTypeAdee;
    }
}
