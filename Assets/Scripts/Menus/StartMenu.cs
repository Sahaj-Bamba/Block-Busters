using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    [SerializeField] private GameObject resultMenu;
    [SerializeField] private GameObject nameMenu;
    [SerializeField] private GameObject launcherMenu;

    [SerializeField] private TMP_InputField playerNameI;

    [SerializeField] private StringReference runState;
    [SerializeField] private StringReference gameName;
    [SerializeField] private StringReference playerName;

    private int runStateValue;
    private TMP_Text resultValue;

    private void Start()
    {
        playerNameI.text = playerName.value;
        resultMenu.SetActive(false);
        nameMenu.SetActive(false);
        launcherMenu.SetActive(false);
        runStateValue = PlayerPrefs.GetInt(runState.value,1);
        resultValue = resultMenu.GetComponentInChildren<TMP_Text>();
        ShowState();
    }

    public void NextState()
    {
        runStateValue++;
        PlayerPrefs.SetInt(runState.value, runStateValue);
        ShowState();
    }

    public void ShowState ()
    {
        switch (runStateValue)
        {
            case 1:
                resultMenu.SetActive(true);
                resultValue.text = "Hello Gamer !!! \n\n Since this is your first time playing " + gameName.value + " lets do some initial configurations first. ";
                break;
            case 2:
                resultMenu.SetActive(false);
                nameMenu.SetActive(true);
                break;
            case 3:
                nameMenu.SetActive(false);
                resultMenu.SetActive(true);
                resultValue.text = "Hello " + playerName.value + " !!! \n\n See how great it sounds now ...  \n\n While we are at it why don't you design your very own launcher as well. ";
                break;
            case 4:
                resultMenu.SetActive(false);
                launcherMenu.SetActive(true);
                break;
            case 5:
                launcherMenu.SetActive(false);
                resultMenu.SetActive(true);
                resultValue.text = "Splendid !!!\n\n I feel pity for all those who will face you. \n\n Since your launcher is complete why don't we try it out in a practice match . ";
                break;
            case 6:
                runStateValue++;
                PlayerPrefs.SetInt(runState.value, runStateValue);
                SceneManager.LoadScene("TutorialBlock");
                break;
            case 7:
                SceneManager.LoadScene("Updates");
                break;
        }
    }

    public void UpdateName (string value)
    {
        playerName.value = value;
    }

}
