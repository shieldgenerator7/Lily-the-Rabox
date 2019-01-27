using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheakpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll2D)
    {
        if (coll2D.gameObject.CompareTag("Player"))
        {
            coll2D.gameObject.GetComponent<Respawn>().currentCheakpoint = transform;
            coll2D.gameObject.GetComponent<PlayerController>().playSoundCheckPoint();
        }
    }
}
