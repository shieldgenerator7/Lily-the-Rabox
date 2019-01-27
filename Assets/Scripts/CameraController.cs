using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject followTarget;
    public GameObject FollowTarget
    {
        get { return followTarget; }
        set
        {
            followTarget = value;
            offset.x = offset.y = 0;
        }
    }

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - followTarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget)
        {
            transform.position = followTarget.transform.position + offset;
        }
    }

    public void setFollowTarget(GameObject go, bool clearOffset)
    {
        followTarget = go;
        if (clearOffset)
        {
            offset.x = offset.y = 0;
        }
        else
        {
            offset = transform.position - go.transform.position;
        }
    }
}
