using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LauncherPart : ScriptableObject
{

    [SerializeField] private int fireRate;
    [SerializeField] private int recoveryRate;
    [SerializeField] private int shootStrength;
    private string partType;

    [SerializeField] private int ElementBooster;
    [SerializeField] private Element element;
    [SerializeField] private new string name;

    public string PartType
    {
        get { return partType; }
        set { partType = value; }
    }

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
