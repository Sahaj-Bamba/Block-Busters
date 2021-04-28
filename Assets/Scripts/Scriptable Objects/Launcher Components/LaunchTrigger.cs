using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LaunchTrigger", menuName = "Launcher/LaunchTrigger")]
public class LaunchTrigger : LauncherPart
{
    private void Awake()
    {
        this.PartType = "Trigger";
    }
}
