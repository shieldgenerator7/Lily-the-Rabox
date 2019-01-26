using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 3;
    public float jumpSpeed = 5;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float finalX = rb2d.velocity.x;
        float finalY = rb2d.velocity.y;
        if (horizontal != 0)
        {
            finalX = horizontal * moveSpeed;
        }
        else
        {
            finalX = 0;
        }
        if (vertical > 0 || Input.GetButton("Jump"))
        {
            finalY = vertical * jumpSpeed;
        }
        //Actually move the character
        Vector2 velocity = rb2d.velocity;
        velocity.x = finalX;
        velocity.y = finalY;
        rb2d.velocity = velocity;
    }
}
