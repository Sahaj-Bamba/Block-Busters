using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StringConstantToTMP_text : MonoBehaviour
{

    private TMP_Text label;
    [SerializeField] private StringConstant stringConstant;

    private void Start()
    {
        label = GetComponent<TMP_Text>();
        label.text = stringConstant.value;
    }

}
