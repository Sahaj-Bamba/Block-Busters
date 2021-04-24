using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SettingsMenu : MonoBehaviour
{
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

        if (PlayerPrefs.HasKey("GamerName")) { username.text = PlayerPrefs.GetString("GamerName"); }
        if (PlayerPrefs.HasKey("GamerControlsValue")) { controls.value = PlayerPrefs.GetInt("GamerControlsValue"); }
        if (PlayerPrefs.HasKey("GamerVolume")) { volume.value = PlayerPrefs.GetFloat("GamerVolume"); }
        if (PlayerPrefs.HasKey("GamerSensitivity")) { sensitivity.value = PlayerPrefs.GetFloat("GamerSensitivity"); }
        if (PlayerPrefs.HasKey("GamerVibrations")) { vibrations.isOn = PlayerPrefs.GetInt("GamerVibrations") == 1; }

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

        PlayerPrefs.SetString("GamerName", username.text);
    }
    public void UpdateControls()
    {
        PlayerPrefs.SetString("GamerControlsName", controls.captionText.text);
        PlayerPrefs.SetInt("GamerControlsValue", controls.value);
    }
    public void UpdateVolume()
    {
        PlayerPrefs.SetFloat("GamerVolume", volume.value);
    }
    public void UpdateSensitivity()
    {
        PlayerPrefs.SetFloat("GamerSensitivity", sensitivity.value);
    }
    public void UpdateVibrations()
    {
        PlayerPrefs.SetInt("GamerVibrations", vibrations.isOn ? 1 : 0);
    }

}
