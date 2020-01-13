using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPausedAdee = false;

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

    void Pause()
    {
        PauseMenuUIAdee.SetActive(true);
        Time.timeScale = 0f;
        gameIsPausedAdee = true;
    }

    public void Resume()
    {
        PauseMenuUIAdee.SetActive(false);
        Time.timeScale = 1f;
        gameIsPausedAdee = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("start");
        Time.timeScale = 1f;
        gameIsPausedAdee = false;
    }
}
