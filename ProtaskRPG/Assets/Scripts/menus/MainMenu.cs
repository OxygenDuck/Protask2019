using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Main menu handler
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //loading new scene after clicking play
        SceneManager.LoadScene("characterCreation");
    }

    public void QuitGame()
    {
        //quiting game after clicking quit
        Application.Quit();
    }
}
