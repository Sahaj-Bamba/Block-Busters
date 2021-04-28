using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Body", menuName = "Launcher/Body")]
public class Body : LauncherPart
{
    private void Awake()
    {
        this.PartType = "Body";
    }
}
