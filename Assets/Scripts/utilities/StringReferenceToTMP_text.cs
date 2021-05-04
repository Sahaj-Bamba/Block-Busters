using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StringReferenceToTMP_text : MonoBehaviour
{

    private TMP_Text label;
    [SerializeField] private StringReference stringConstant;

    private void Start()
    {
        label = GetComponent<TMP_Text>();
        label.text = stringConstant.value;
    }

}
