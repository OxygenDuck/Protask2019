using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldMovement : MonoBehaviour
{
    //The speed at which the character moves
    private readonly float worldSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Main Camera").transform.position = transform.position;
        GameObject.Find("Main Camera").transform.position += new Vector3(0, 0, -0.5f);
        GameObject.Find("Main Camera").transform.SetParent(transform); //Set main camera to this object
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.gameIsPausedAdee && WorldController.worldstate == Worldstate.MOVE)
        {
            //Movement
            if (Input.GetKey(KeyCode.W))//go up
            {
                transform.position += new Vector3(0, worldSpeed);
            }
            else if (Input.GetKey(KeyCode.S))//go down
            {
                transform.position += new Vector3(0, -worldSpeed);
            }

            if (Input.GetKey(KeyCode.A))//go left
            {
                transform.position += new Vector3(-worldSpeed, 0);
            }
            else if (Input.GetKey(KeyCode.D))//go right
            {
                transform.position += new Vector3(worldSpeed, 0);
            }
        }      
    }
}
