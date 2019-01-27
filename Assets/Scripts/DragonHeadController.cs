using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHeadController : MonoBehaviour
{
    public PolygonCollider2D pc2d;
    public float moveSpeed = 1;
    public int startPoint = 0;
    public bool forward = true;//move forward through the points
    public bool head = true;
    public DragonHeadController forwardLink;

    private int targetPoint = 0;
    private Vector3 convertedTarget;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition(startPoint);
        if (head)
        {
            transform.position = convertedTarget;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, convertedTarget, moveSpeed * Time.deltaTime);
        if (transform.position == convertedTarget)
        {
            targetPoint += (forward) ? 1 : -1;
            targetPoint = (targetPoint + pc2d.points.Length) % pc2d.points.Length;
            targetPosition(targetPoint);

            transform.up = convertedTarget - transform.position;

        }
        if (forwardLink != null && forwardLink.targetPoint >= targetPoint + 2)
        {
            targetPosition(forwardLink.targetPoint);
        }
    }

    void targetPosition(int index)
    {
        targetPoint = index;
        convertedTarget = pc2d.transform.TransformPoint(pc2d.points[targetPoint]);
    }
}
