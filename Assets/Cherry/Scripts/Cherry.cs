using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public GameObject collectable;
    private void OnTriggerEnter2D(Collider2D coll2D)
    {
        if (coll2D.gameObject.CompareTag("Player")) {
            collectable.GetComponent<Collectables>().cherry++;
            coll2D.gameObject.GetComponent<PlayerController>().playSoundPickup();
            Destroy(gameObject);
            }
    }
}
