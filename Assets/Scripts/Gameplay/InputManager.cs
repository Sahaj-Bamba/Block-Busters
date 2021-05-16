using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    [SerializeField] private PlayerActions playerActions;

    public void OnMove(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        playerActions.RawInput = inputMovement;
    }

    public void OnShot(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            playerActions.Shot();
        }


/*      Debug.Log(value.interaction);
        Debug.Log(value.started);
        Debug.Log(value.action);
        Debug.Log(value.control);
        Debug.Log(value.duration);
        Debug.Log(value.interaction);
        Debug.Log(value.performed);
        Debug.Log(value.startTime);
        Debug.Log(value.time);
*/  
    }

}
