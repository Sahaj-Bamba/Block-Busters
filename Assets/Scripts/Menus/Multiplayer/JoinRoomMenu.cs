using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinRoomMenu : MonoBehaviour
{

    [SerializeField] private RoomDetails roomDetails;

    [SerializeField] private GameObject privateMenu;
    [SerializeField] private GameObject publicMenu;

    private void OnEnable()
    {
        PublicRoom();
    }

    public void PrivateRoom()
    {
        roomDetails.isPrivate = true;
        privateMenu.SetActive(true);
        publicMenu.SetActive(false);
    }

    public void PublicRoom ()
    {
        roomDetails.isPrivate = false;
        privateMenu.SetActive(false);
        publicMenu.SetActive(true);
    }



}
