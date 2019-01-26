using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftAndRight : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int space;
    int movementUp;
    int movementDown;
    bool upOrDown = true;
    //true is up false is down
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (upOrDown == true)
        {
            if (movementUp < space)
            {
                rb2d.velocity = Vector3.left;
                movementUp++;
            }
            if (movementUp == space)
            {
                movementUp = 0;
                upOrDown = false;
            }
        }
        if (upOrDown == false)
        {
            if (movementDown < space)
            {
                rb2d.velocity = Vector3.right;
                movementDown++;
            }
            if (movementDown == space)
            {
                movementDown = 0;
                upOrDown = true;
            }
        }
    }
}
