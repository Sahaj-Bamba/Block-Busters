using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerMenu : MonoBehaviour
{

    [SerializeField] private GameObject roomMode;
    [SerializeField] private GameObject createRoomMenu;
    [SerializeField] private GameObject createRoomResult;
    [SerializeField] private GameObject joinRoomMenu;
    [SerializeField] private GameObject joinRoomResult;

    private void Start()
    {
        roomMode.SetActive(true);
        createRoomMenu.SetActive(false);
        createRoomResult.SetActive(false);
        joinRoomMenu.SetActive(false);
        createRoomResult.SetActive(false);
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

    public void SubmitCreateRoomDetails()
    {
        createRoomMenu.SetActive(false);
        createRoomResult.SetActive(true);
    }
    public void GoBackToCreateRoomDetails()
    {
        createRoomResult.SetActive(false);
        createRoomMenu.SetActive(true);
    }

    public void SubmitJoinRoomDetails()
    {
        joinRoomMenu.SetActive(false);
        joinRoomResult.SetActive(true);
    }
    public void GoBackToJoinRoomDetails()
    {
        joinRoomResult.SetActive(false);
        joinRoomMenu.SetActive(true);
    }

    public void AllDetailsGotNowStartGame ()
    {
        Debug.Log("Start Game");
    }



}
