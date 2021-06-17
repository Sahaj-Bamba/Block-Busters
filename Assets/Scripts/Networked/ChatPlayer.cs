using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public struct PlayerData
{
    public string name;
}

public class ChatPlayer : NetworkBehaviour
{

    readonly SyncDictionary<int, PlayerData> Players = new SyncDictionary<int,PlayerData>();

    [SerializeField] private StringReference playerName;

    [SerializeField] private TMP_Text[] uiNames;


    public void Start()
    {
        Debug.Log("chatPlayer started");
        base.OnStartClient();
        //    this.playerName = GameObject.Find("DataContainers")?.GetComponent<ChatPlayerData>().player;
        Players.Callback += OnPlayerChange;
        CmdUpdateName(this.playerName.value);

    }

    [Command]
    public void CmdUpdateName(string name)
    {
        PlayerData playerData = new PlayerData();
        playerData.name = name; 
        Players[connectionToClient.connectionId] = playerData;
    }

    void OnPlayerChange(SyncDictionary<int, PlayerData>.Operation op, int key, PlayerData item)
    {

        Debug.Log(op);

        foreach (TMP_Text uiName in uiNames)
        {
            if(uiName.text == "")
            {
                uiName.text = item.name;
            }
        }
    }

}
