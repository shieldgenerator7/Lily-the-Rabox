using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EyeController : MonoBehaviour
{
    //Runtime vars
    [SerializeField]
    private GameObject trackingObject;

    //Runtime constants
    private Vector3 originalPosition;
    private CircleCollider2D cc2d;
    private float radius;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        cc2d = GetComponent<CircleCollider2D>();
        radius = cc2d.radius/2;
    }

    // Update is called once per frame
    void Update()
    {
        lookAt(trackingObject);
    }

    public void trackObject(GameObject go)
    {
        trackingObject = go;
        lookAt(go);
    }

    public void lookAt(GameObject go)
    {
        transform.position = originalPosition + ((go.transform.position - originalPosition).normalized * radius);
    }
}
