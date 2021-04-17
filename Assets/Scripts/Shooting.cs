using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Shooting : NetworkBehaviour
{

    public GameObject marble;
    public GameObject special;
    public Vector3 velocity;
    public float shootDelay;
    private float prevShoot = 0;

    private Transform shootPoint;
    private Rigidbody shootVel;

    private void Start()
    {
        var body = gameObject.transform.Find("Body");
        if (body)
        {
            shootVel = body.gameObject.GetComponent<Rigidbody>();
        }
        else
        { 
            Debug.LogError("No Body on Player");
        }
        shootPoint = gameObject.transform.Find("ShootPoint");
        if (transform.rotation.y != 0)
        {
            velocity *= -1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!hasAuthority)
        {
            return;
        }


        if (Input.GetButton("Fire1") && (Time.time - prevShoot) > shootDelay)
        {

            if (marble)
            {
                CmdSpawnMarble("marble");
            }else
            {
                Debug.Log("Marble object missing");
            }
            prevShoot = Time.time;
        }
        if (Input.GetButton("Jump") && (Time.time - prevShoot) > shootDelay)
        {
            CmdSpawnMarble("marble");
            prevShoot = Time.time;
        }
    }

    [Command]
    void CmdSpawnMarble(string marbleType)
    {
        GameObject marb = null;
        if (marbleType == "marble")
        {
            marb = Instantiate(marble , shootPoint.position,  shootPoint.rotation );
            marb.GetComponent<Rigidbody>().velocity = velocity + shootVel.velocity;
        }
        if (marb)
        {
            NetworkServer.Spawn(marb);
        }
    }

}
