using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    public float multiplier = 0.9f;
    public float limit;
    public Vector3 offset;
    private Transform ply;

    void Start()
    {
        ply = GetComponent<Transform>();
    }

    void FixedUpdate()
    {

        //ply.position = offset;

        Debug.Log(ply.position.x - offset.x);

        if (ply.position.x - offset.x > limit)
        {
            ply.position = new Vector3(limit - 0.01f + offset.x, ply.position.y, ply.position.z);
            return;
        }
        else if (ply.position.x - offset.x < -1 * limit)
        {
            ply.position = new Vector3(-1 * limit + 0.01f + offset.x, ply.position.y, ply.position.z);
            return;
        }

        Debug.Log("Hi");

        float x = Input.acceleration.x * 1f;
        float y = Input.GetAxis("Horizontal") * 1f;

        x = (Math.Abs(x) > Math.Abs(y)) ? x : y;

        /*Debug.Log(x);
        Debug.Log(y);*/

        if (x >= 0.01f || x <= -0.01f)
        {
            ply.Translate(x * multiplier, 0, 0);
        }

    /*    if (x >= 0.01f)
        {
            ply.Translate(x * multiplier, 0, 0);
        }
        Debug.Log("x " + ply.position.x);
    */
    }

}
