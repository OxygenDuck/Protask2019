using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CcColorManager : MonoBehaviour
{
    public SpriteRenderer head;
    public SpriteRenderer body;
    public SpriteRenderer legs;

    public void SetColors()
    {
        float headRed = GameObject.Find("sldHeadRed").GetComponent<Slider>().value / 100;
        float headGreen = GameObject.Find("sldHeadGreen").GetComponent<Slider>().value / 100;
        float headBlue = GameObject.Find("sldHeadBlue").GetComponent<Slider>().value / 100;

        float bodyRed = GameObject.Find("sldBodyRed").GetComponent<Slider>().value / 100;
        float bodyGreen = GameObject.Find("sldBodyGreen").GetComponent<Slider>().value / 100;
        float bodyBlue = GameObject.Find("sldBodyBlue").GetComponent<Slider>().value / 100;

        float legsRed = GameObject.Find("sldLegsRed").GetComponent<Slider>().value / 100;
        float legsGreen = GameObject.Find("sldLegsGreen").GetComponent<Slider>().value / 100;
        float legsBlue = GameObject.Find("sldLegsBlue").GetComponent<Slider>().value / 100;
        
        head.color = new Color(headRed, headGreen, headBlue);
        body.color = new Color(bodyRed, bodyGreen, bodyBlue);
        legs.color = new Color(legsRed, legsGreen, legsBlue);
    }

    public void CloseCC()
    {
        //DEBUG: Show battle character with saved settings
        GameObject newCharacter = Instantiate(Resources.Load<GameObject>("Prefabs/BattleCharacter"));
        newCharacter.GetComponent<Character>().SetColors(head.color, body.color, legs.color);

        gameObject.transform.parent.gameObject.SetActive(false);

        for (int i = 0; i < 3; i++)
        {
            GameObject sprite = Instantiate(Resources.Load<GameObject>("Prefabs/SpriteObject"), newCharacter.transform);
            sprite.transform.SetParent(newCharacter.transform);
            switch (i)
            {
                case 0: sprite.GetComponent<SpriteObject>().SetSprite("Character/Battle/battleHead"); break;
                case 1: sprite.GetComponent<SpriteObject>().SetSprite("Character/Battle/battleBody"); break;
                case 2: sprite.GetComponent<SpriteObject>().SetSprite("Character/Battle/battleLegs"); break;
            }
            sprite.GetComponent<SpriteObject>().SetColor(newCharacter.GetComponent<Character>().colors[i]);
        }

        //Spawn World character
        SceneManager.LoadScene("world");
        GameObject worldCharacter = Instantiate(Resources.Load<GameObject>("Prefabs/OverworldCharacter"));
    }
}
