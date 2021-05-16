using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntReferenceToTMP_text : MonoBehaviour
{

    private TMP_Text label;
    [SerializeField] private IntReference intConstant;

    private void Start()
    {
        label = GetComponent<TMP_Text>();
        label.text = intConstant.value.ToString();
    }

    public void Updated()
    {
        label.text = intConstant.value.ToString();
    }

}
