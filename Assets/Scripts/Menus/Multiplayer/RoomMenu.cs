using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RoomMenu : MonoBehaviour
{

    [SerializeField] private StringReference serverAddress;
    [SerializeField] private StringReference playerName;
    [SerializeField] private StringReference errorMessage;

    [SerializeField] private RoomDetails roomDetails;

    [SerializeField] private TMP_InputField roomName;
    [SerializeField] private TMP_InputField roomPassword;
    [SerializeField] private Toggle isPrivate = null;
    [SerializeField] private TMP_Text result;

    [SerializeField] private Button submit;

    [SerializeField] private GameObject[] disableOnNotPrivate;

    private string endPoint = "room/checkRoomName";

    void Start()
    {
        roomName.text = roomDetails.name;
        roomPassword.text = roomDetails.Password;
        if (isPrivate)
        {
            isPrivate.isOn = roomDetails.isPrivate;
        }
        CheckAll();
        CheckPrivateDisabled();
    }

    private void CheckPrivateDisabled ()
    {
        if (roomDetails.isPrivate) 
        {
            foreach (GameObject gameObject in disableOnNotPrivate)
            {
                gameObject.SetActive(true);
            }
            return;
        }
        foreach (GameObject gameObject in disableOnNotPrivate)
        {
            gameObject.SetActive(false);
        }
    }

    public void CheckAll()
    {
        submit.interactable = false;
        result.text = "";

        if (string.IsNullOrWhiteSpace(roomDetails.name))
        {
            result.text = "Name can't be empty";
            return;
        }

        if (roomDetails.isPrivate)
        {
            if (string.IsNullOrWhiteSpace(roomDetails.Password))
            {
                result.text = "Password can't be empty";
                return;
            }
        }

        submit.interactable = true;

    }

    public void UpdateName()
    {
        roomDetails.name = roomName.text;
        CheckAll();
    }

    public void UpdatePassword()
    {
        roomDetails.Password = roomPassword.text;
        CheckAll();
    }
    public void UpadteIsPrivate()
    {
        roomDetails.isPrivate = isPrivate.isOn;
        CheckPrivateDisabled();
        CheckAll();
    }

    public void SubmitRoomDetails()
    {
        submit.interactable = false;
        StartCoroutine(CheckName());
    }


    IEnumerator CheckName()
    {
        result.text = " Loading ...";

        JSONObject myData = new JSONObject(JSONObject.Type.OBJECT);
        myData.AddField("name", roomDetails.name);
        myData.AddField("username", playerName.value);

        using (UnityWebRequest www = UnityWebRequest.Put(serverAddress.value + endPoint, myData.ToString()))
        {

            www.method = UnityWebRequest.kHttpVerbGET;
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Accept", "application / json");

            yield return www.SendWebRequest();

            JSONObject res = new JSONObject(www.downloadHandler.text);

            if (res["error"] && res["error"].b)
            {
                result.text = res["message"].str;
                yield break;
            }

            if (www.result != UnityWebRequest.Result.Success)
            {
                result.text = errorMessage.value;
                Debug.Log(www.error);
                yield break;
            }

            result.text = res["message"].str;
            Successful();
        }

    }

    public void Successful()
    {
        MultiplayerMenu multiplayerMenu = this.GetComponentInParent<MultiplayerMenu>();
        if (multiplayerMenu)
        {
            multiplayerMenu.SubmitCreateRoomDetails();
        }
    }

}
