using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JoinRoomResult : MonoBehaviour
{

    [SerializeField] private RoomDetails roomDetails;
    [SerializeField] private TMP_Text content;

    [SerializeField] private Button proceed;
    [SerializeField] private Button goBack;

    private void OnEnable()
    {

        proceed.interactable = false;
        goBack.interactable = false;

        content.text = "Trying to join room \n loading ... ";

        Debug.Log("do stuff with room details joining");
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
