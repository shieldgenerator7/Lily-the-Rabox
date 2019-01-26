using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheakpoint : MonoBehaviour
{
    public GameObject thePlayer;
    private Animator flower;
    private void Start()
    {
        flower = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D coll2D)
    {
        if (coll2D.gameObject.CompareTag("Player"))
        {
            thePlayer.GetComponent<Respawn>().currentCheakpoint = transform;
            flower.SetBool("IsOpen", true);
        }
    }
}
