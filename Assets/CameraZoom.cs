using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float newOrthographicSize = 2;
    public float origOrtho = 5;
    private Camera cam;
    CircleCollider2D cc2d;
    float radius;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cc2d = GetComponent<CircleCollider2D>();
        radius = cc2d.radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (cc2d.bounds.Contains((Vector2)cam.transform.position))
        {
            cam.orthographicSize = Mathf.Lerp(origOrtho, newOrthographicSize, 1-((transform.position - cam.transform.position).magnitude / radius));
        }
    }
}
