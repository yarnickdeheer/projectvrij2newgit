using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleRoute : MonoBehaviour
{
    public Transform[] route;

    public Vector3 pointOne;
    public Vector3 pointTwo;
    public Vector3 curvePoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rechtdoor is:
        float distanceBetweenOneAndTwo = Vector3.Distance(pointOne, pointTwo);
        float moveSpeed = 0.1f;

        transform.position = transform.position + (pointTwo - pointOne).normalized * moveSpeed;
        if(Vector3.Distance(transform.position, pointTwo) < 2)
        {
            transform.position = pointTwo;
        }
    }
}
