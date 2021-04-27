using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Launcher" , menuName = "Launcher/Launcher")]
public class Launcher : ScriptableObject
{
    public Core core;
    public LaunchBarrel launchBarrel;
    public LaunchTrigger launchTrigger;
    public Body body;
    public TopFunnel topFunnel;
}
