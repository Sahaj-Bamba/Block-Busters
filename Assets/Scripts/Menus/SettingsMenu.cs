using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;


public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameConfig gameConfig;

    [SerializeField] private GameObject qualityMenu;
    [SerializeField] private GameObject gameplayMenu;

    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_Dropdown controls;
    [SerializeField] private Slider volume;
    [SerializeField] private Slider sensitivity;
    [SerializeField] private Toggle vibrations;

    public void Start()
    {
        gameplayMenu.SetActive(true);
        qualityMenu.SetActive(false);

        LoadSettingsData();

        username.text = gameConfig.name.value;
        controls.value = gameConfig.controls;
        volume.value = gameConfig.volume;
        sensitivity.value = gameConfig.sensitivity;
        vibrations.isOn = gameConfig.vibrations;

    }

    public void ActivateQualityMenu()
    {
        gameplayMenu.SetActive(false);
        qualityMenu.SetActive(true);
    }
    public void ActivateGameplayMenu()
    {
        gameplayMenu.SetActive(true);
        qualityMenu.SetActive(false);
    }

    public void UpdateName()
    {
        if (string.IsNullOrWhiteSpace(username.text)) { return; }

        gameConfig.name.value = username.text;
    }
    public void UpdateControls()
    {
        gameConfig.controls = controls.value;
        gameConfig.controlsName = controls.captionText.text;
    }
    public void UpdateVolume()
    {
        gameConfig.volume =  volume.value;
    }
    public void UpdateSensitivity()
    {
        gameConfig.sensitivity =  sensitivity.value;
    }
    public void UpdateVibrations()
    {
        gameConfig.vibrations = vibrations.isOn;
    }


    private void checkOrCreate(string path)
    {
        if( !Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    public void BackToMenu()
    {
        this.SaveSettingsData();    
        this.GetComponent<MainMenu>().StartMenu();
    }

    public void Quit()
    {
        this.SaveSettingsData();
        this.GetComponent<MainMenu>().StartQuit();
    }

    public void SaveSettingsData()
    {
        checkOrCreate(Path.Combine(Application.persistentDataPath, "GameSave"));

        JSONObject myData = new JSONObject(JSONObject.Type.OBJECT);

        myData.AddField("name", gameConfig.name.value);
        myData.AddField("controls", gameConfig.controls);
        myData.AddField("volume", gameConfig.volume);
        myData.AddField("sensitivity", gameConfig.sensitivity);
        myData.AddField("vibrations", gameConfig.vibrations);

        File.WriteAllText(Path.Combine(Application.persistentDataPath, "GameSave", "settings.json"), myData.ToString());
    }
    public void LoadSettingsData()
    {
        checkOrCreate(Path.Combine(Application.persistentDataPath, "GameSave"));
        
        string data = File.ReadAllText(Path.Combine(Application.persistentDataPath, "GameSave", "settings.json"));

        JSONObject myData = new JSONObject(data);

        gameConfig.name.value = myData["name"].str;
        gameConfig.controls = (int) myData["controls"].n;
        gameConfig.volume = (int) myData["volume"].n;
        gameConfig.sensitivity = (int) myData["sensitivity"].n;
        gameConfig.vibrations = myData["vibrations"].b;

    }

}
