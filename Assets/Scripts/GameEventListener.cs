using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{

    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private UnityEvent Response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }

    private void OnDisable()
    {
        gameEvent.UnRegisterListener(this);
    }

}
