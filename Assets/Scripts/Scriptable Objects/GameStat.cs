using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Stat", menuName = "Game Stat")]
public class GameStat : ScriptableObject
{
    public StringConstant key;
    public IntReference value;
}
