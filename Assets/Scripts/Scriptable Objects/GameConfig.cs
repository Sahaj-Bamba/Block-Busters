using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Game Configuration", menuName ="GameConfig")]
public class GameConfig : ScriptableObject
{

    public new StringReference name;
    public int controls;
    public string controlsName;
    public float volume;
    public float sensitivity;
    public bool vibrations;

}
