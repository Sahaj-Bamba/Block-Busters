using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RoomResult : MonoBehaviour
{

    [SerializeField] private StringReference playerName;
    [SerializeField] private StringReference serverAddress;
    [SerializeField] private StringReference errorMessage;

    [SerializeField] private RoomDetails roomDetails;
    [SerializeField] private TMP_Text content;

    [SerializeField] private Button proceed;
    [SerializeField] private Button goBack;


    private string endPoint = "";
    private string msg = "";

    public void CreateRoom()
    {
        endPoint = "room/create";
        msg = "Started Room Creation process. \n\n Allocating resources. \n\n Please wait this can take upto 2 minutes. ";
        StartRoomRequest();
    }

    public void JoinRoom()
    {
        endPoint = "room/getRoomDetails";
        msg = "Trying to join room ";
        StartRoomRequest();
    }

    private void StartRoomRequest()
    {
        StartCoroutine(RoomRequest());
        content.text = msg;
    }

    private void OnEnable()
    {
        proceed.interactable = false;
        goBack.interactable = false;
    }

    IEnumerator RoomRequest()
    {
        content.text = msg + "\n\n Loading ...";

        JSONObject myData = new JSONObject(JSONObject.Type.OBJECT);
        myData.AddField("name", roomDetails.name);
        myData.AddField("password", roomDetails.Password);
        myData.AddField("username", playerName.value);

        using (UnityWebRequest www = UnityWebRequest.Put(serverAddress.value + endPoint, myData.ToString()))
        {

            www.method = UnityWebRequest.kHttpVerbPOST;
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Accept", "application / json");

            yield return www.SendWebRequest();

            JSONObject res = new JSONObject(www.downloadHandler.text);

            if (res["error"] && res["error"].b)
            {
                content.text = res["message"].str;
                Cancelled();
                yield break;
            }

            if (www.result != UnityWebRequest.Result.Success)
            {
                content.text = errorMessage.value;
                Debug.Log(www.error);
                Cancelled();
                yield break;
            }

            roomDetails.ip = res["ip"].str;
            roomDetails.port = (int)res["port"].n;

            content.text = res["message"].str;
            Successful();
        }

    }


    private void Cancelled()
    {
        goBack.interactable = true;
    }

    private void Successful()
    {
        proceed.interactable = true;
    }


}
