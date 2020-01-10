using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLoader : MonoBehaviour
{
    public static SpriteLoader instance;

    public Dictionary<string, Vector2[]> tileUvMapAdee;

    void Awake()
    {
        instance = this;

        //making map of the tiles
        tileUvMapAdee = new Dictionary<string, Vector2[]>();

        //load all sprites
        Sprite[] spritesAdee = Resources.LoadAll<Sprite>("Sprites/world");

        float imageWidthAdee = 0f;
        float imageHeightAdee = 0f;

        //loop through all sprites
        foreach (Sprite s in spritesAdee)
        {
            if(s.rect.x + s.rect.width > imageWidthAdee)
            {
                imageWidthAdee = s.rect.x + s.rect.width;
            }

            if (s.rect.y + s.rect.height > imageHeightAdee)
            {
                imageHeightAdee = s.rect.y + s.rect.height;
            }
        }

        //loop to sprite to add them to tiles
        foreach (Sprite s in spritesAdee)
        {
            Vector2[] uvsAdee = new Vector2[4];

            uvsAdee[0] = new Vector2(s.rect.x / imageWidthAdee, s.rect.y / imageHeightAdee); //bottom left corner
            uvsAdee[1] = new Vector2((s.rect.x + s.rect.width) / imageWidthAdee, s.rect.y / imageHeightAdee); // bottom right corner
            uvsAdee[2] = new Vector2(s.rect.x / imageWidthAdee, (s.rect.y + s.rect.height) / imageHeightAdee); // top left corner
            uvsAdee[3] = new Vector2((s.rect.x + s.rect.width) / imageWidthAdee, (s.rect.y + s.rect.height) / imageHeightAdee); // top right corner

            //adding sprites to the tiles
            tileUvMapAdee.Add(s.name, uvsAdee);

            Debug.Log(s.name + ": " + uvsAdee[0] + "," + uvsAdee[1] + "," + uvsAdee[2] + "," + uvsAdee[3] + ",");
        }
    }

    //get the tiles
    public Vector2[] GetTileUvs(Tile tile)
    {
        string keyAdee = tile.typeAdee.ToString();

        if (tileUvMapAdee.ContainsKey(keyAdee))
        {
            return tileUvMapAdee[keyAdee];
        }
        else
        {
            Debug.LogError("failed to get tile uvs");
            return tileUvMapAdee["Void"];
        }
    }
}
