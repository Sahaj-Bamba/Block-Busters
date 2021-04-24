using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartTraining()
    {
        SceneManager.LoadScene("Training");
    }

    public void StartMultiplayer()
    {
        SceneManager.LoadScene("Multiplayer");
    }

    public void StartWorkshop()
    {
        SceneManager.LoadScene("Workshop");
    }

    public void StartSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void StartStore()
    {
        SceneManager.LoadScene("Store");
    }

    public void StartAchievements()
    {
        SceneManager.LoadScene("Achievements");
    }

    public void StartCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void StartFeedback()
    {
        SceneManager.LoadScene("Feedback");
    }
    public void StartBugs()
    {
        SceneManager.LoadScene("Bugs");
    }

    public void StartQuit()
    {
        Application.Quit();
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
