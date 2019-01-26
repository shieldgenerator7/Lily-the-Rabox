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
    private RaycastHit2D groundedHit;
    private bool Grounded
    {
        get { return groundedHit.collider != null; }
        set { throw new System.NotImplementedException(); }
    }

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
            if (Grounded || !wallInWay(horizontal))
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
                if (Grounded)
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
        //Update the player rotation
        updateRotation();
        //Update the animation
        animator.SetBool("isWalking", horizontal != 0);
        animator.SetBool("isJumping", finalY > 0 && vertical > 0);
        animator.SetBool("isGrounded", Grounded);
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
        groundedHit = obstacleInDirection(-transform.up);
        if (Grounded)
        {
            jumps = 0;
        }
    }

    private bool wallInWay(float direction)
    {
        return obstacleInDirection(transform.right * Mathf.Sign(direction)) != null;
    }

    private RaycastHit2D obstacleInDirection(Vector2 dir)
    {
        RaycastHit2D[] results = new RaycastHit2D[10];
        int count = coll2d.Cast(dir, results, groundSearchDistance, true);
        for (int i = 0; i < count; i++)
        {
            RaycastHit2D rch2d = results[i];
            if (rch2d)
            {
                return rch2d;
            }
        }
        return new RaycastHit2D();
    }

    private void updateRotation()
    {
        if (Grounded)
        {
            Debug.Log("grounded hit normal: " + groundedHit.normal);
            if (Vector3.Angle(groundedHit.normal, transform.up) < 90)
            {
                transform.up = groundedHit.normal;
            }
            else
            {
                transform.up = Vector3.up;
            }
        }
        else
        {
            transform.up = Vector3.up;
        }
    }
}
