using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UpdatesMenu : MonoBehaviour
{

    [SerializeField] private StringReference playerName;
    [SerializeField] private StringReference serverAddress;
    [SerializeField] private StringReference errorMessage;

    [SerializeField] private TMP_Text result;

    [SerializeField] private GameObject updatePrefab;
    [SerializeField] private Transform updateContainer;
    [SerializeField] private GameObject updateMenu;
    [SerializeField] private Button next;


    private string searchString;
    private List <GameObject> updates = new List<GameObject>();
    private string endPoint = "updates";

    private void OnEnable()
    {
        next.interactable = false;
        result.gameObject.SetActive(true);
        updateMenu.SetActive(false);
        StartCoroutine(GetUpdates());
    }

    IEnumerator GetUpdates()
    {
        result.text = "Getting updates \n\n Loading ...";

        JSONObject myData = new JSONObject(JSONObject.Type.OBJECT);
        myData.AddField("username", playerName.value);

        using (UnityWebRequest www = UnityWebRequest.Put(serverAddress.value + endPoint, myData.ToString()))
        {

            www.method = UnityWebRequest.kHttpVerbGET;
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Accept", "application / json");

            yield return www.SendWebRequest();

            next.interactable = true;
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

            foreach (JSONObject update in res["updates"].list)
            {
                GameObject up = Instantiate(updatePrefab, new Vector3(0, 0, 0), Quaternion.identity);
                up.transform.SetParent(updateContainer);
                up.transform.Find("Content").GetComponent<TMP_Text>().text = update["content"].str;
                up.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                updates.Add(up);
            }

            result.gameObject.SetActive(false);
            updateMenu.SetActive(true);
            StartCoroutine(UpdatePosY(res["updates"].list.Count));
        }

    }

    private IEnumerator UpdatePosY(float value)
    {

        yield return 0;
        RectTransform rect = updateContainer.gameObject.GetComponent<RectTransform>();
        rect.anchoredPosition += 50 * (value) * Vector2.down;

    }


}
