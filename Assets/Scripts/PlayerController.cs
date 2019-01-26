using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 3;
    public float jumpSpeed = 5;
    public float maxJumps = 2;//how many jumps she can do w/o touching ground
    public float groundSearchDistance = 0.01f;

    private float prevHorizontal = 0;
    private float prevVertical = 0;
    private float jumps = 0;//how many jumps have been made since last touching ground
    private bool grounded = false;

    private Animator animator;
    private Rigidbody2D rb2d;
    private Collider2D coll2d;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
            if (grounded || !wallInWay(horizontal))
            {
                finalX = horizontal * moveSpeed;
            }
        }
        else if (prevHorizontal != 0)
        {
            finalX = 0;
        }
        if (vertical > 0)
        {
            if (prevVertical <= 0)
            {
                jumps++;
                if (grounded)
                {
                    finalY = vertical * jumpSpeed;
                }
                else if (jumps <= maxJumps)
                {
                    finalY = vertical * jumpSpeed;
                }
            }
        }
        else if (prevVertical > 0)
        {
            finalY = Mathf.Min(0, rb2d.velocity.y);
            jumps++;
        }
        //Actually move the character
        Vector2 velocity = rb2d.velocity;
        velocity.x = finalX;
        velocity.y = finalY;
        rb2d.velocity = velocity;
        //Update the player looking direction
        if (horizontal != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(horizontal);
            transform.localScale = scale;
        }
        //Update the animation
        animator.SetBool("isWalking", horizontal != 0);
        //Update previous input directions
        prevHorizontal = horizontal;
        prevVertical = vertical;
    }

    private void FixedUpdate()
    {
        checkGroundedState();
    }

    private void checkGroundedState()
    {
        if (obstacleInDirection(Vector2.down))
        {
            jumps = 0;
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    private bool wallInWay(float direction)
    {
        return obstacleInDirection(Vector2.right * Mathf.Sign(direction));
    }

    private bool obstacleInDirection(Vector2 dir)
    {
        RaycastHit2D[] results = new RaycastHit2D[10];
        int count = coll2d.Cast(dir, results, groundSearchDistance, true);
        for (int i = 0; i < count; i++)
        {
            RaycastHit2D rch2d = results[i];
            if (rch2d)
            {
                return true;
            }
        }
        return false;
    }
}
