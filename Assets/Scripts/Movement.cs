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
/*
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
*/

        float mobx = Input.acceleration.x * 1f;
        float deskx = Input.GetAxis("Horizontal") * 1f;

        float x = (Math.Abs(mobx) > Math.Abs(deskx)) ? mobx : deskx;
        x *= multiplier;
        if (x >= 0.01f || x <= -0.01f)
        {
            if(Math.Abs(ply.position.x + x ) > limit)
            {
                ply.position = new Vector3(x > 0 ? limit : -1 * limit, ply.position.y, ply.position.z);
            }
            else
            {
                ply.Translate(x * multiplier, 0, 0);
            }
        }

    }

}
