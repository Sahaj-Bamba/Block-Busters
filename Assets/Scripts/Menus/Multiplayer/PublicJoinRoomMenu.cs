using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class PublicJoinRoomMenu : MonoBehaviour
{

    [SerializeField] private StringReference playerName;
    [SerializeField] private StringReference serverAddress;
    [SerializeField] private StringReference errorMessage;

    [SerializeField] private TMP_Text result;

    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private Transform roomContainer;
    [SerializeField] private GameObject roomMenu;

    private string searchString;
    private Dictionary<string,GameObject> rooms = new Dictionary<string, GameObject>();
    private string endPoint = "room/getPublic";
    

    public void updateSearchString (string value)
    {
        this.searchString = value;
        foreach (KeyValuePair<string,GameObject> room in rooms)
        {
            if (room.Key.Contains(value))
            {
                room.Value.SetActive(true);
            }else
            {
                room.Value.SetActive(false);
            }
        }
        StartCoroutine(UpdatePosY(10000));
    }


    private void OnEnable()
    {
        result.gameObject.SetActive(true);
        roomMenu.SetActive(false);
        StartCoroutine(GetPublicRooms());
    }

    IEnumerator GetPublicRooms()
    {
        result.text = "Getting rooms \n\n Loading ...";

        JSONObject myData = new JSONObject(JSONObject.Type.OBJECT);
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

            foreach(JSONObject room in res["rooms"].list)
            {
                rooms[room.str] = Instantiate(roomPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                rooms[room.str].transform.SetParent(roomContainer);
                rooms[room.str].transform.Find("Name").GetComponent<TMP_Text>().text = room.str;
                rooms[room.str].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }

            result.gameObject.SetActive(false);
            roomMenu.SetActive(true);
            StartCoroutine(UpdatePosY(res["rooms"].list.Count));
        }

    }

    private IEnumerator UpdatePosY(float value)
    {

        yield return 0;
        RectTransform rect = roomContainer.gameObject.GetComponent<RectTransform>();
        rect.anchoredPosition += 50 * (value) * Vector2.down;

    }

}
