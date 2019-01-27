using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObject : MonoBehaviour
{
    public Vector2 initialDirection = Vector2.zero;
    public Sprite destroyedSprite;
    public float destroyDelay = 0.2f;
    public float destroySpeed = 0.01f;

    private float destroyStartTime = 0;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (destroyStartTime > 0)
        {
            Color c = sr.color;
            c.a = (Time.time - destroyStartTime) / destroyDelay;
            sr.color = c;
            if (Time.time > destroyStartTime + destroyDelay)
            {
                Destroy(gameObject);
            }
        }
    }

    public void destroy()
    {
        destroyStartTime = Time.time;
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = rb2d.velocity.normalized * destroySpeed;
        sr.sprite = destroyedSprite;
    }
}
