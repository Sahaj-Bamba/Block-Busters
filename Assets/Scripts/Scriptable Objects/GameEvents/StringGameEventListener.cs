using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringGameEventListener : MonoBehaviour
{
    [SerializeField] private StringGameEvent gameEvent;
    [SerializeField] private StringUnityEvent Response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnRegisterListener(this);
    }

    public void OnEventRaised(string value)
    {
        Response.Invoke(value);
    }

}
