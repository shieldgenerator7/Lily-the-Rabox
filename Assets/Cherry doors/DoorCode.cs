using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCode : MonoBehaviour
{
    public int cherryCount;
    public GameObject cherryFinder;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cherryFinder.GetComponent<Collectables>().cherry == cherryCount)
        {
            Destroy(gameObject);
        }
    }
}
