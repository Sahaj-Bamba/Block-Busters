using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CreateRoomMenu : MonoBehaviour
{

    [SerializeField] private RoomDetails roomDetails;

    [SerializeField] private TMP_InputField roomName;
    [SerializeField] private TMP_InputField roomPassword;
    [SerializeField] private Toggle isPrivate;
    [SerializeField] private TMP_Text result;

    [SerializeField] private Button submit;

    [SerializeField] private GameObject[] disableOnNotPrivate;

    void Start()
    {
        roomName.text = roomDetails.name;
        roomPassword.text = roomDetails.password;
        isPrivate.isOn = roomDetails.isPrivate;
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
            if (string.IsNullOrWhiteSpace(roomDetails.password))
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
        roomDetails.password = roomPassword.text;
        CheckAll();
    }
    public void UpadteIsPrivate()
    {
        roomDetails.isPrivate = isPrivate.isOn;
        CheckPrivateDisabled();
        CheckAll();
    }

}
