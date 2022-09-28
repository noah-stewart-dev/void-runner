using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string playGameLevel; // Name of level to load
    public string mainMenu; // Name of main menu

    public void PlayGame()
    {
        // Load level with given level name
        Application.LoadLevel(playGameLevel);
    }

    public void QuitToMenu()
    {
        Application.LoadLevel(mainMenu);
    }

    public void QuitGame()
    {
        // Quit application
        Application.Quit();
    }
}
