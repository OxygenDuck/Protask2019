using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLoader : MonoBehaviour
{
    public static SpriteLoader instance;

    Dictionary<string, Vector2[]> tileUvMap;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        tileUvMap = new Dictionary<string, Vector2[]>();

        Sprite[] sprites = Resources.LoadAll<Sprite>("");

        float imageWidth = 0f;
        float imageHeight = 0f;

        foreach (Sprite s in sprites)
        {
            if(s.rect.x + s.rect.width > imageWidth)
            {
                imageWidth = s.rect.x + s.rect.width;
            }

            if (s.rect.y + s.rect.height > imageHeight)
            {
                imageHeight = s.rect.y + s.rect.height;
            }
        }

        foreach (Sprite s in sprites)
        {
            Vector2[] uvs = new Vector2[4];

            uvs[0] = new Vector2(s.rect.x / imageWidth, s.rect.y / imageHeight); //bottom left corner
            uvs[1] = new Vector2((s.rect.x + s.rect.width) / imageWidth, s.rect.y / imageHeight); // bottom right corner
            uvs[2] = new Vector2(s.rect.x / imageWidth, (s.rect.y + s.rect.height) / imageHeight); // top left corner
            uvs[3] = new Vector2((s.rect.x + s.rect.width) / imageWidth, (s.rect.y + s.rect.height) / imageHeight); // top right corner

            tileUvMap.Add(s.name, uvs);

            Debug.Log(s.name + ": " + uvs[0] + "," + uvs[1] + "," + uvs[2] + "," + uvs[3] + ",");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2[] GetTileUvs(Tile tile)
    {
        string key = tile.type.ToString();

        if (tileUvMap.ContainsKey(key))
        {
            return tileUvMap[key];
        }
        else
        {
            Debug.LogError("failed to get tile uvs");
            return tileUvMap["Void"];
        }
    }
}
