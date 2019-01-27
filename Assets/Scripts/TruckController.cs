using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    public float moveSpeed = 5;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb2d.velocity;
        vel.x = Vector2.left.x * moveSpeed;
        rb2d.velocity = vel;
        if (transform.position.y < -100)
        {
            Destroy(gameObject);
        }
    }
}
