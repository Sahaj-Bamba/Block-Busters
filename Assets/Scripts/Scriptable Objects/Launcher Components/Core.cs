using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Core", menuName = "Launcher/Core")]
public class Core : LauncherPart
{
    private void Awake()
    {
        this.PartType = "Core";
    }
}
