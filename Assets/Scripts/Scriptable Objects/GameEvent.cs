using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Game Event")]
public class GameEvent : ScriptableObject
{

    private List<GameEventListener> gameEventListeners = new List<GameEventListener>();

    public void Raise ()
    {
        for (int i = gameEventListeners.Count ; i >= 0 ; i--)
        {
            gameEventListeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener gameEventListener)
    {
        if (!gameEventListeners.Contains(gameEventListener)) { gameEventListeners.Add(gameEventListener); }
    }
    public void UnRegisterListener(GameEventListener gameEventListener)
    {
        if (gameEventListeners.Contains(gameEventListener)) { gameEventListeners.Remove(gameEventListener); }
    }

}
