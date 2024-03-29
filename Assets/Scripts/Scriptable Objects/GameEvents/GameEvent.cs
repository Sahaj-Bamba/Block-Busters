using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Game Events/Game Event")]
public class GameEvent : ScriptableObject
{

    protected List<GameEventListener> gameEventListeners = new List<GameEventListener>();

    
    public virtual void Raise ()
    {
        for (int i = gameEventListeners.Count-1 ; i >= 0 ; i--)
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
