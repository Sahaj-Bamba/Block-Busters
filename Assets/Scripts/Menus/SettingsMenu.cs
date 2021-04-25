using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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

        username.text = gameConfig.name;
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

        gameConfig.name = username.text;
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

}
