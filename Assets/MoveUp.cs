using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float moveSpeed = 1;
    public Vector2 dir = Vector2.up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)dir * moveSpeed * Time.deltaTime;
    }
}
