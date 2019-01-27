using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    public float moveSpeed = 1;//in units/second
    public float maxDirectionChangeAmount = 100;//in degrees
    public float steeringDirectionDuration = 1;//in seconds

    private float directionChangeAmount = 0;
    private float lastDirChangeTime = 0;
    private Vector3 direction = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastDirChangeTime + steeringDirectionDuration)
        {
            lastDirChangeTime = Time.time;
            directionChangeAmount = Random.Range(-maxDirectionChangeAmount, maxDirectionChangeAmount);
        }
        //direction = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + (rotateSpeed * Time.deltaTime));
        direction = Quaternion.AngleAxis(directionChangeAmount, Vector3.forward) * direction;
        direction.Normalize();
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
