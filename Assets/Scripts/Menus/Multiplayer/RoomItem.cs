using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomItem : MonoBehaviour
{

    [SerializeField] private RoomDetails room;
    
    public void Submit ()
    {
        room.isPrivate = false;
        room.name = this.gameObject.transform.Find("Name").GetComponent<TMP_Text>().text;
        GameObject.FindObjectOfType<MultiplayerMenu>().SubmitJoinRoomDetails();
    }

}
