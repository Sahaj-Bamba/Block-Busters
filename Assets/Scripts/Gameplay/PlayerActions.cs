using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    [SerializeField] private GameConfig gameConfig;

    [SerializeField] private float multiplier = 0.9f;
    [SerializeField] public float limit;

    [SerializeField] private Transform player;

    [SerializeField] private GameObject marble;
    [SerializeField] private GameObject special;
    [SerializeField] private Vector3 shootVelocity;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootDelay;
    
    private float prevShoot = 0;


    private Vector2 rawInput;

    public Vector2 RawInput
    {
        get { return rawInput; }
        set { rawInput = value; }
    }

    private void FixedUpdate()
    {
        Move();
    }


    public void Move()
    {

        Vector2 xy = rawInput;

        if (xy.sqrMagnitude <= 0.1)
        {
            return;
        }

        float x = player.position.x + xy.x * gameConfig.sensitivity * multiplier;

        float newx = Mathf.Clamp(x, -1 * limit, limit);

        player.position = new Vector3(newx, player.position.y, player.position.z);

    }

    public void Shot ()
    {
        if ((Time.time - prevShoot) > shootDelay)
        {
            GameObject marb = Instantiate(marble, shootPoint.position, shootPoint.rotation);
            marb.GetComponent<Rigidbody>().velocity = shootVelocity;
            prevShoot = Time.time;
        }
    }


}
