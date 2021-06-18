using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ChatClientManager : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> uiNames;

    [SerializeField] private ChatPlayerData chatPlayerData;

    public void UpdatePlayer()
    {

        int max = chatPlayerData.players.Count;

        for ( int i=0; i<max; i++)
        {
            uiNames[i].text = chatPlayerData.players[i].name;
        }

    }



}
