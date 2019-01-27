using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObject : MonoBehaviour
{
    public Vector2 initialDirection = Vector2.zero;
    public float maxLifeDuration = 0;
    public Sprite destroyedSprite;
    public float destroyDelay = 0.2f;
    public float destroySpeed = 0.01f;

    public ObjectSpawner objectSpawner;

    private float destroyStartTime = 0;
    private float spawnedTime = 0;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        spawnedTime = Time.time;
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
                sr.color = new Color(0, 0, 0, 0);
                GetComponent<Collider2D>().enabled = false;
                Destroy(gameObject);
            }
        }
        if (maxLifeDuration > 0)
        {
            if (Time.time > spawnedTime + maxLifeDuration)
            {
                maxLifeDuration = 0;
                destroy();
            }
        }
    }

    public void destroy()
    {
        destroyStartTime = Time.time;
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = rb2d.velocity.normalized * destroySpeed;
        if (destroyedSprite != null)
        {
            sr.sprite = destroyedSprite;
        }
    }
}
