using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Marble : NetworkBehaviour
{

    public override void OnStartServer()
    {
        base.OnStartServer();

        // only simulate ball physics on server
        //  try to find something


    }



}
