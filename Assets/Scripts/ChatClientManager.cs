using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class ChatClientManager : MonoBehaviour
{

    [SerializeField] private GameObjectsSet Players;
    [SerializeField] private GameObjectsSet LocalPlayer;
    [SerializeField] private List<TMP_Text> uiNames;

    [SerializeField] private GameObject messageTemplate;
    [SerializeField] private Transform messageContainer;
    [SerializeField] private TMP_InputField messageField;

    public void Start()
    {
        Players.Initialize();
        LocalPlayer.Initialize();
    }

    public void UpdatePlayerUI()
    {

        for (int i = 0; i < Players.Count(); i++)
        {
            uiNames[i].text = Players.GetItem(i).GetComponent<ChatPlayer>()?.playerName;
        }

    }

    public void SendUserMessage(string message)
    {
        if (string.IsNullOrEmpty(message)) { return; }
        
        messageField.text = "";
        LocalPlayer.GetItem(0)?.GetComponent<ChatPlayer>()?.SendUserMessage(message);

    }


    public void MessageReceived(string message)
    {
        GameObject msg = Instantiate(messageTemplate, new Vector3(0, 0, 0), Quaternion.identity);
        msg.GetComponent<TMP_Text>().text = message;
        msg.GetComponent<Transform>().SetParent(messageContainer, false);
    }


    /*
    
    readonly SyncList<PlayerData> players = new SyncList<PlayerData>();

//    [SerializeField] private GameEvent playerUpdated;
    
    [SerializeField] private List<TMP_Text> uiNames;

    [SerializeField] private StringReference playerName;

    private void Start()
    {
        players.Callback += OnPlayerChange;
    }

    public void SetPlayer()
    {
        Debug.Log("Start Setting Player");
        CmdSetPlayerName();
    }


    [Command]
    public void CmdSetPlayerName()
    {
        PlayerData playerData = new PlayerData();
        playerData.name = playerName.value;
        playerData.connectionID = connectionToClient.connectionId;
        players.Add(playerData);
        netIdentity.RemoveClientAuthority();
    }

    private void OnPlayerChange(SyncList<PlayerData>.Operation op, int index, PlayerData oldItem, PlayerData newItem)
    {
        Debug.Log("Player Updated");
        switch (op)
        {
            case SyncList<PlayerData>.Operation.OP_ADD:
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
        UpdatePlayerUI();
    }


    
    public void UpdatePlayerUI()
    {

        int max = players.Count;

        for ( int i=0; i<max; i++)
        {
            Debug.Log(players[i].name);
            uiNames[i].text = players[i].name;
        }

    }
    
    */

}
