using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Worldstate { MOVE, BATTLE }

public class WorldController : MonoBehaviour
{
    static public Worldstate worldstate = Worldstate.MOVE;
    static public Color[] CharacterColors = new Color[] { Color.white, Color.white, Color.white };
    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = Instantiate(Resources.Load<GameObject>("Prefabs/OverworldCharacter"), new Vector3(World.instance.widthAdee /2,World.instance.heightAdee /2,-0.5f), new Quaternion());
        Player.name = "Player";
        for (int i = 0; i < 3; i++)
        {
            string characterPart = "";
            switch (i)
            {
                case 0: characterPart = "Head"; break;
                case 1: characterPart = "Body"; break;
                case 2: characterPart = "Legs"; break;
            }
            Player.transform.Find(characterPart).GetComponent<SpriteRenderer>().color = WorldController.CharacterColors[i];
        }
    }
}
