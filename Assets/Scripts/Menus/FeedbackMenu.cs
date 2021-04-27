using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class FeedbackMenu : MonoBehaviour
{
    [SerializeField] private new TMP_InputField name;
    [SerializeField] private TMP_InputField email;
    [SerializeField] private TMP_InputField content;
    [SerializeField] private Button submit;
    [SerializeField] private TMP_Text result;

    [SerializeField] private StringConstant serverAddress;

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
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        
        //formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
        formData.Add(new MultipartFormDataSection("name="+name.text));
        formData.Add(new MultipartFormDataSection("email="+email.text));
        formData.Add(new MultipartFormDataSection("content="+content.text));

        UnityWebRequest www = UnityWebRequest.Post(serverAddress.value + "submitFeedback", formData);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            result.text = www.error;
        }
        else
        {
            result.text = "Your words have been recorded in our scroll of honour. ";
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
