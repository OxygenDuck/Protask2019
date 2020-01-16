using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Pause menu handler
public class PauseMenu : MonoBehaviour
{
    //Game paused boolean
    public static bool gameIsPausedAdee = false;

    //The pause menu UI
    public GameObject PauseMenuUIAdee;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPausedAdee)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //Pause the game
    void Pause()
    {
        PauseMenuUIAdee.SetActive(true);
        Time.timeScale = 0f;
        gameIsPausedAdee = true;
    }

    //Resume the game
    public void Resume()
    {
        PauseMenuUIAdee.SetActive(false);
        Time.timeScale = 1f;
        gameIsPausedAdee = false;
    }

    //Quit game
    public void Quit()
    {
        Application.Quit();
    }

    //Go back to main menu
    public void Menu()
    {
        SceneManager.LoadScene("start");
        Time.timeScale = 1f;
        gameIsPausedAdee = false;
    }
}
