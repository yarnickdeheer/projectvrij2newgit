using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleCam : MonoBehaviour
{
    public Transform playerTransform;
    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, 5, -12.5f), 0.3f);
=======
        //transform.position = Vector3.Lerp(transform.position, new Vector3(0, 5, -12.5f), 0.3f);
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + new Vector3(0,4,-10), 0.5f);
>>>>>>> main
        transform.LookAt(playerTransform);
    }
}
