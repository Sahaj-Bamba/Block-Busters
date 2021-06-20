using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class ChatPlayer : NetworkBehaviour
{
    [SerializeField] private StringReference player;
    [SerializeField] private ChatPlayerSet Players;
    [SerializeField] private GameEvent UpdatePlayer;

    [SyncVar(hook = nameof(HandleDisplayNameChanged))]
    public string playerName = "";

    public override void OnStartClient()
    {
        base.OnStartClient();
        Players.Add(this);
        Debug.Log("Checking local player ");

        if (isLocalPlayer)
        {
            Debug.Log("Is local player ");
            SetName(player.value); }
    }

    public void HandleDisplayNameChanged(string oldValue, string newValue) => UpdateDisplay();

    public void UpdateDisplay() 
    {
        Debug.Log("Updated");
        UpdatePlayer.Raise();
    }

    [Command]
    public void SetName(string name)
    {
        Debug.Log("Updating");
        playerName = name;
    }


    /*
    
    public override void OnStartAuthority()
    {

        Debug.Log("chatPlayer started");
        chatClientManager = GameObject.Find("ChatManager")?.GetComponent<ChatClientManager>();
        
        CmdGetAuthority(this.chatClientManager.netIdentity);
    
    }

    [Command]
    public void CmdGetAuthority(NetworkIdentity identity)
    {
        if (chatClientManager == null) { return; }

        Debug.Log("Got authority of ChatClientManager");
        identity.AssignClientAuthority(connectionToClient);
        RpcGotAuthority();
    }

    [ClientRpc]
    public void RpcGotAuthority()
    {
        if(chatClientManager == null) { return; }

        chatClientManager.SetPlayer();
    }


    */
    /*
    [Command]
    public void CmdUpdateName(string name)
    {
        PlayerData playerData = new PlayerData();
        playerData.name = name;
        playerData.connectionID = connectionToClient.connectionId;
        players.Add(playerData);
    }


    
    private void OnPlayerChange(SyncList<PlayerData>.Operation op, int index, PlayerData oldItem, PlayerData newItem)
    {
        Debug.Log("Player Updated");
        switch (op)
        {
            case SyncList<PlayerData>.Operation.OP_ADD:
                this.playerData.players.Add(newItem);
                break;
            case SyncList<PlayerData>.Operation.OP_CLEAR:
                // list got cleared
                break;
            case SyncList<PlayerData>.Operation.OP_INSERT:
                // index is where it got added in the list
                // newItem is the new item
                break;
            case SyncList<PlayerData>.Operation.OP_REMOVEAT:
                // index is where it got removed in the list
                // oldItem is the item that was removed
                break;
            case SyncList<PlayerData>.Operation.OP_SET:
                // index is the index of the item that was updated
                // oldItem is the previous value for the item at the index
                // newItem is the new value for the item at the index
                break;
        }
        playerUpdated.Raise();

    }

    */
}