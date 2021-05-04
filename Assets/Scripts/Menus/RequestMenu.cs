using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class RequestMenu : MonoBehaviour
{
    [SerializeField] private string endPoint;
    [SerializeField] private new TMP_InputField name;
    [SerializeField] private TMP_InputField email;
    [SerializeField] private TMP_InputField content;
    [SerializeField] private Button submit;
    [SerializeField] private TMP_Text result;

    [SerializeField] private StringReference serverAddress;
    [SerializeField] private StringReference playerName;
    [SerializeField] private StringReference errorMessage;

    private void Awake()
    {
        submit.interactable = false;
        result.text = "";
    }

    public void FeedbackSubmit ()
    {

        submit.interactable = false;

        if (string.IsNullOrWhiteSpace(name.text)) { return; }
        if (string.IsNullOrWhiteSpace(email.text)) { return; }
        if (string.IsNullOrWhiteSpace(content.text)) { return; }

        StartCoroutine(SendFeedback());

    }
    IEnumerator SendFeedback()
    {
        result.text = "Loading ...";
        
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();

        JSONObject myData = new JSONObject(JSONObject.Type.OBJECT);
        myData.AddField("name", name.text);
        myData.AddField("email", email.text);
        myData.AddField("content", content.text);
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
            name.text = "";
            email.text = "";
            content.text = "";
            
        }

    }

    public void CheckName()
    {
        if (string.IsNullOrWhiteSpace(name.text)) { 
            result.text = "Name can't be empty";
            return; 
        }
        CheckAll();
    }
    public void CheckEmail()
    {
        if (string.IsNullOrWhiteSpace(email.text)) {
            result.text = "Email can't be empty";
            return; 
        }
        CheckAll();
    }
    public void CheckContent()
    {
        if (string.IsNullOrWhiteSpace(content.text)) {
            result.text = "Content can't be empty";
            return;
        }
        CheckAll();
    }

    public void CheckAll()
    {
        submit.interactable = false;

        if (string.IsNullOrWhiteSpace(name.text))
        {
            result.text = "Name can't be empty";
            return;
        }
        if (string.IsNullOrWhiteSpace(email.text))
        {
            result.text = "Email can't be empty";
            return;
        }
        if (string.IsNullOrWhiteSpace(content.text))
        {
            result.text = "Content can't be empty";
            return;
        }

        submit.interactable = true;
        result.text = "";

    }

}
