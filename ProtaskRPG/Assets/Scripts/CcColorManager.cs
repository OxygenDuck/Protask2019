using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CcColorManager : MonoBehaviour
{
    public SpriteRenderer head; //Head Preview Object
    public SpriteRenderer body; //Body Preview Object
    public SpriteRenderer legs; //Legs Preview Object

    //Set the colors of the preview
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


    //Close the Character Creator
    public void CloseCC()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        WorldController.CharacterColors = new Color[] { head.color, body.color, legs.color };

        //Spawn World character
        SceneManager.LoadScene("world");
        GameObject worldCharacter = Instantiate(Resources.Load<GameObject>("Prefabs/OverworldCharacter"));
    }
}
