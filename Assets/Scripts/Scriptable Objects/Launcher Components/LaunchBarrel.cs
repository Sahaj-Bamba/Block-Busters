using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LaunchBarrel", menuName = "Launcher/LaunchBarrel")]
public class LaunchBarrel : LauncherPart
{
    private void Awake()
    {
        this.PartType = "Barrel";
    }
}
