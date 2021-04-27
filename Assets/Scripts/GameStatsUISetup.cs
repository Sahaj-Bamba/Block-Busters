using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatsUISetup : MonoBehaviour
{
    [SerializeField] private TMP_Text key;
    [SerializeField] private TMP_Text value;

    public GameStat gameStat;

    void Start()
    {
        key.text = gameStat.key.value;
        value.text = gameStat.value.value.ToString();
    }

}
