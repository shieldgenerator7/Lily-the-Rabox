using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 3;
    public float jumpSpeed = 5;
    public float groundSearchDistance = 0.05f;

    private float prevHorizontal = 0;
    private float prevVertical = 0;
    private bool grounded = false;

    private Rigidbody2D rb2d;
    private Collider2D coll2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coll2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Input.GetButton("Jump") || vertical > 0)
        {
            vertical = 1;
        }
        float finalX = rb2d.velocity.x;
        float finalY = rb2d.velocity.y;
        if (horizontal != 0)
        {
            finalX = horizontal * moveSpeed;
        }
        else if (prevHorizontal != 0)
        {
            finalX = 0;
        }
        if (vertical > 0)
        {
            if (grounded)
            {
                finalY = vertical * jumpSpeed;
            }
        }
        else if (prevVertical > 0)
        {
            finalY = Mathf.Min(0, rb2d.velocity.y);
        }
        //Actually move the character
        Vector2 velocity = rb2d.velocity;
        velocity.x = finalX;
        velocity.y = finalY;
        rb2d.velocity = velocity;
        //
        prevHorizontal = horizontal;
        prevVertical = vertical;
    }

    private void FixedUpdate()
    {
        checkGroundedState();
    }

    private void checkGroundedState()
    {
        grounded = false;
        RaycastHit2D[] results = new RaycastHit2D[10];
        int count = coll2d.Cast(Vector2.down, results, groundSearchDistance, true);
        for (int i = 0; i < count; i++)
        {
            RaycastHit2D rch2d = results[i];
            if (rch2d)
            {
                grounded = true;
                break;
            }
        }
    }
}
