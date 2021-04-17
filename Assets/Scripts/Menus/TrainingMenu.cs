using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingMenu : MonoBehaviour
{

    [SerializeField] private GameObject trainingMode;
    [SerializeField] private GameObject gameMode;

    private string trainingModeName;
    private string gameModeName;

    public void SetTrainingMode (string tm)
    {
        trainingModeName = tm;
        trainingMode.SetActive(false);
        gameMode.SetActive(true);
    }
    
    public void SetGameMode (string gm)
    {
        gameModeName = gm;
        StartGame();
    }

    private void StartGame ()
    {
        SceneManager.LoadScene(trainingModeName + gameModeName);
    }

}
