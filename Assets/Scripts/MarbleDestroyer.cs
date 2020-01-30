using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleDestroyer : MonoBehaviour
{
    public float leaveTime = 5f;

    void Start()
    {
        StartCoroutine(destroy());
    }

    private IEnumerator destroy()
    {

        yield return new WaitForSeconds(leaveTime);
        Destroy(gameObject);       

    }

}
