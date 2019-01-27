using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlatform : MonoBehaviour
{
    public GameObject platform;
    private void OnTriggerEnter2D(Collider2D coll2D)
    {
        if (coll2D.gameObject.CompareTag("Player"))
        {
            platform.SetActive(false);
            platform.SetActive(true);
        }
    }
}
