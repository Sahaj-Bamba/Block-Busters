using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mirror;

public class Movement : NetworkBehaviour
{
    [SerializeField] private float multiplier = 0.9f;
    [SerializeField] public float limit;
    [SerializeField] public Vector3 offset;
    [SerializeField] private Transform ply;
    [SerializeField] private Transform cameraTransform;

    void Start()
    {
        ply = GetComponent<Transform>();
    }

    public override void OnStartAuthority()
    {
        cameraTransform = gameObject.transform.Find("Main Camera");
        Debug.Log("in on start auth");
        if (cameraTransform)
        {
            cameraTransform.gameObject.SetActive(true);
        }
    }

    [Client]
    void FixedUpdate()
    {

        if (!hasAuthority) { return; }

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



        //      reverser is used to ensure right movement for both the players
        //      mobx is from mobile accellerometer
        //      deskx is from desktop keyboard keys

        float mobx = Input.acceleration.x * 1f;
        float deskx = Input.GetAxis("Horizontal") * 1f;
        float reverser = ply.rotation.y == 0 ? 1 : -1;
        float x = (Math.Abs(mobx) > Math.Abs(deskx)) ? mobx : deskx;
        x *= multiplier;


        // this condition check is to discard simple high sensitive accellerometer input
        if (x >= 0.01f || x <= -0.01f)
        {
            if(Math.Abs(ply.position.x + x ) > limit)
            {
                ply.position = new Vector3(x > 0 ? limit : -1 * limit, ply.position.y, ply.position.z);
            }
            else
            {
                ply.Translate(x * multiplier * reverser, 0, 0);
            }
        }

    }

}
