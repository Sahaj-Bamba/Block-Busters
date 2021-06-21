using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StringGameEvent", menuName = "Game Events/String Game Event")]
public class StringGameEvent : ScriptableObject
{
    private List<StringGameEventListener> gameEventListeners = new List<StringGameEventListener>();

    public virtual void Raise(string value)
    {
        for (int i = gameEventListeners.Count - 1; i >= 0; i--)
        {
            gameEventListeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(StringGameEventListener gameEventListener)
    {
        if (!gameEventListeners.Contains(gameEventListener)) { gameEventListeners.Add(gameEventListener); }
    }
    public void UnRegisterListener(StringGameEventListener gameEventListener)
    {
        if (gameEventListeners.Contains(gameEventListener)) { gameEventListeners.Remove(gameEventListener); }
    }


}