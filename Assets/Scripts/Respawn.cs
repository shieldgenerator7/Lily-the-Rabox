using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform currentCheakpoint;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            respawn();
        }
    }
    void respawn()
    {
        transform.position = currentCheakpoint.position;
    }
}
