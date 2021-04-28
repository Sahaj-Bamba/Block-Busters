using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Funnel", menuName = "Launcher/TopFunnel")]
public class TopFunnel : LauncherPart
{
    private void Awake()
    {
        this.PartType = "Funnel";
    }
}
