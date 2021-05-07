using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Room", menuName = "RoomDetails")]
public class RoomDetails : ScriptableObject
{
    public new string name;
    private string password;
    public bool isPrivate;
    public string ip;
    public int port;

    public string Password
    {
        get { return isPrivate ? password : ""; }
        set { password = value; }
    }

}
