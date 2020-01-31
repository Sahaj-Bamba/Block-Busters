using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject marble;
    public Transform shootPoint;
    public Rigidbody shootVel;
    public Vector3 velocity;
    public float shootDelay;
    private float prevShoot = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && (Time.time - prevShoot) > shootDelay)
        {
            GameObject gb = Instantiate(marble, shootPoint.position, shootPoint.rotation);
            gb.GetComponent<Rigidbody>().velocity = velocity + shootVel.velocity;
            prevShoot = Time.time;
        }
    }
}
