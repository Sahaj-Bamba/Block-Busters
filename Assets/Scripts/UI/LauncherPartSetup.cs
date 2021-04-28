using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LauncherPartSetup : MonoBehaviour
{
    [SerializeField] private Launcher launcher;
    [SerializeField] private string launcherPartType;
    [SerializeField] private LauncherPart[] launcherParts;
    private LauncherPart launcherPart;
    private int counter;

    [SerializeField] private TMP_Text partType;
    [SerializeField] private new TMP_Text name;
    [SerializeField] private TMP_Text fireRate;
    [SerializeField] private TMP_Text recoveryRate;
    [SerializeField] private TMP_Text shootStrength;
    [SerializeField] private TMP_Text element;

    void Start()
    {
        if (launcherPartType == launcher.core.PartType)
        {
            launcherPart = launcher.core;
            counter = System.Array.IndexOf(launcherParts, launcher.core);
        }
        else if (launcherPartType == launcher.launchBarrel.PartType)
        {
            launcherPart = launcher.launchBarrel;
            counter = System.Array.IndexOf(launcherParts, launcher.launchBarrel);
        }
        else if (launcherPartType == launcher.launchTrigger.PartType)
        {
            launcherPart = launcher.launchTrigger;
            counter = System.Array.IndexOf(launcherParts, launcher.launchTrigger);
        }
        else if (launcherPartType == launcher.body.PartType)
        {
            launcherPart = launcher.body;
            counter = System.Array.IndexOf(launcherParts, launcher.body);
        }
        else if (launcherPartType == launcher.topFunnel.PartType)
        {
            launcherPart = launcher.topFunnel;
            counter = System.Array.IndexOf(launcherParts, launcher.topFunnel);
        }

        updateUI();
    }

    private void updateUI ()
    {
        partType.text = launcherPart.PartType;
        name.text = launcherPart.Name;
        fireRate.text = launcherPart.FireRate.ToString();
        recoveryRate.text = launcherPart.RecoveryRate.ToString();
        shootStrength.text = launcherPart.ShootStrength.ToString();
        element.text = launcherPart.GetElement.Name;
    }

    public void NextPartCommon ()
    {
        if (launcherPartType == launcher.core.PartType)
        {
            NextCore();
        }
        else if (launcherPartType == launcher.launchBarrel.PartType)
        {
            NextLaunchBarrel();
        }
        else if (launcherPartType == launcher.launchTrigger.PartType)
        {
            NextLaunchTrigger();
        }
        else if (launcherPartType == launcher.body.PartType)
        {
            NextBody();
        }
        else if (launcherPartType == launcher.topFunnel.PartType)
        {
            NextTopFunnel();
        }
        updateUI();
    }

    public void NextCore()
    {
        launcher.core = (Core)NextPart();
    }
    public void NextLaunchTrigger()
    {
        launcher.launchTrigger = (LaunchTrigger)NextPart();
    }
    public void NextLaunchBarrel()
    {
        launcher.launchBarrel = (LaunchBarrel)NextPart();
    }
    public void NextBody()
    {
        launcher.body = (Body)NextPart();
    }
    public void NextTopFunnel()
    {
        launcher.topFunnel = (TopFunnel)NextPart();
    }

    private LauncherPart NextPart()
    {
        counter++;
        counter %= launcherParts.Length;
        return launcherPart = launcherParts[counter];
    }

}
