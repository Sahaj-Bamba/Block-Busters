using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{
   
    void Start()
    {
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "BlockDestroyer")
        {
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<MeshRenderer>());
            Destroy(GetComponent<BoxCollider>());
        }
    }

}
