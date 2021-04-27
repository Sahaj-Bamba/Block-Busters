using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LaunchBarrel", menuName = "Launcher/LaunchBarrel")]
public class LaunchBarrel : ScriptableObject
{
    [SerializeField] private int fireRate;
    [SerializeField] private int recoveryRate;
    [SerializeField] private int shootStrength;

    [SerializeField] private int ElementBooster;
    [SerializeField] private Element element;
    [SerializeField] private new string name;

    public string Name
    {
        get { return name; }
    }

    public int FireRate
    {
        get { return fireRate; }
    }

    public int RecoveryRate
    {
        get { return recoveryRate; }
    }

    public int ShootStrength
    {
        get { return shootStrength; }
    }

    public Element GetElement
    {
        get { return element; }
    }


}
