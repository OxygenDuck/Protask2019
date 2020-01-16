using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//World state Enum
public enum Worldstate { MOVE, BATTLE }

//World controller class
public class WorldController : MonoBehaviour
{
    static public Worldstate worldstate = Worldstate.MOVE; //The current World state
    static public Color[] CharacterColors = new Color[] { Color.white, Color.white, Color.white }; //Character colors

    // Start is called before the first frame update
    void Start()
    {
        //Spawn the character and set colors
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
