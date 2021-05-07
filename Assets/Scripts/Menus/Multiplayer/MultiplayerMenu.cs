using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerMenu : MonoBehaviour
{

    [SerializeField] private GameObject roomMode;
    [SerializeField] private GameObject createRoomMenu;
    [SerializeField] private GameObject joinRoomMenu;
    [SerializeField] private GameObject roomResult;

    private void Start()
    {
        roomMode.SetActive(true);
        createRoomMenu.SetActive(false);
        joinRoomMenu.SetActive(false);
        roomResult.SetActive(false);
    }

    public void CreateRoom ()
    {
        roomMode.SetActive(false);
        createRoomMenu.SetActive(true);
    }

    public void JoinRoom ()
    {
        roomMode.SetActive(false);
        joinRoomMenu.SetActive(true);
    }

    public void GoBackToModeSelect ()
    {
        roomResult.SetActive(false);
        roomMode.SetActive(true);
    }

    public void SubmitCreateRoomDetails()
    {
        createRoomMenu.SetActive(false);
        roomResult.SetActive(true);
        this.GetComponentInChildren<RoomResult>().CreateRoom();
    }

    public void SubmitJoinRoomDetails()
    {
        joinRoomMenu.SetActive(false);
        roomResult.SetActive(true);
        this.GetComponentInChildren<RoomResult>().JoinRoom();
    }

    public void AllDetailsGotNowStartGame ()
    {
        Debug.Log("Start Game");
    }

}
