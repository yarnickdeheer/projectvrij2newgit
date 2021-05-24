using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleCam : MonoBehaviour
{
    public Transform playerTransform;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + new Vector3(0,4,-10), 0.5f);
        transform.LookAt(playerTransform);
    }
}
