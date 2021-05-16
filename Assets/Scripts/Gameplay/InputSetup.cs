using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSetup : MonoBehaviour
{
    [SerializeField] private GameConfig gameConfig;

    [SerializeField] private GameObject buttonPannel;
    [SerializeField] private GameObject joystickPannel;

    private void OnEnable()
    {
        buttonPannel.SetActive(false);
        joystickPannel.SetActive(false);

        switch (gameConfig.controls)
        {
            case 0:
//                InputSystem.EnableDevice(Accelerometer.current);
                break;
            case 1:
                buttonPannel.SetActive(true);
                break;
            case 2:
                joystickPannel.SetActive(true);
                break;
        }
    }

}
