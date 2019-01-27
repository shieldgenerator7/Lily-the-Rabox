using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{
    public GameObject unboxPrefab;
    public Sprite unboxedSprite;

    public string breakTag = "Ground";//an object with this tag will break this object if it collides with it
    public float breakOpenDelay = 1;

    //Runtime vars
    private float breakOpenTime = 0;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
     if (breakOpenTime > 0 && Time.time > breakOpenTime + breakOpenDelay)
        {
            GameObject spawn = Instantiate(unboxPrefab);
            spawn.transform.position = transform.position;
            CameraController cam = FindObjectOfType<CameraController>();
            if (cam.playerObject == gameObject) { 
                cam.playerObject = spawn;
            }
            Destroy(gameObject);
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(breakTag))
        {
            breakOpen();
        }
    }

    public void breakOpen()
    {
        sr.sprite = unboxedSprite;
        breakOpenTime = Time.time;
    }
}
