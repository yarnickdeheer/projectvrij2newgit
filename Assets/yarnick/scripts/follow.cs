using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{

    Vector3 lastPosition;
    public Transform gg;
    public bool front, back, left, right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var direction = transform.position - lastPosition;
        var localDirection = transform.InverseTransformDirection(direction);
        lastPosition = transform.position;
       // Debug.Log(localDirection);

        this.transform.position = gg.position;


        //Depth
        if (localDirection.z >0)
        {
            // naar achter
            front = false;
            back = true;
        }
        else if(localDirection.z < 0)
        {
            //naar voren
            back = false;
            front = true;
        }
        
        if (localDirection.x > 0)
        {
            // naar links
            right = false;
            left = true;
        }
        else if (localDirection.x < 0)
        {
            //naar voren
            left = false;
            right = true;
        }
    }
}
