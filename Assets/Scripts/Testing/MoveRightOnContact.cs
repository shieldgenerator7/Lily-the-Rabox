using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightOnContact : MonoBehaviour
{
    Vector3 originalPosition;
    private Rigidbody2D rb2d;
    public int space;
    bool movement = false;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        originalPosition = gameObject.transform.position;   
    }
    private void OnEnable()
    {
        movement = false;
        if (originalPosition != Vector3.zero)
        {
            gameObject.transform.position = originalPosition;
        }
    }
    private void OnCollisionEnter2D()
    {
        movement = true;
    }
    void FixedUpdate()
    {
        if (movement == true)
        {
            rb2d.velocity = Vector3.right*space;
        }
    }
}
