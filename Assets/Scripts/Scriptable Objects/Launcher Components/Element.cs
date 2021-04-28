using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Element", menuName = "Launcher/Element")]
public class Element : ScriptableObject
{
    [SerializeField] private new string name;

    public string Name
    {
        get { return name; }
    } 
}
