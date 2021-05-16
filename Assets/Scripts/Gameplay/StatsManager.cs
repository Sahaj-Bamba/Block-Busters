using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    [SerializeField] IntReference marblesShot;
    [SerializeField] IntReference marblesLeft;
    [SerializeField] IntReference time;

    [SerializeField] GameEvent eachSecond;

    private void OnEnable()
    {
        time.value = 0;
        marblesShot.value = 0;
        marblesLeft.value = 30;
        StartCoroutine(EachSecond());
    }

    public IEnumerator EachSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time.value++;
            eachSecond.Raise();
        }
    }

    public void OnMarbleShot()
    {
        marblesShot.value++;
        marblesLeft.value--;
    }

    private void OnDisable()
    {
        StopCoroutine(EachSecond());
    }

}
