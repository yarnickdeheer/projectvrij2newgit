using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    // Start is called before the first frame update
    public RouteFollow turtle;
    public TurtleTrigger turtls;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionstay(Collision collision)
    {
        Debug.Log("hit anything" + " " + collision.gameObject.tag +"  dasda" + turtls.ride);
         
        if (collision.gameObject.tag == "rockks" && turtls.ride == false)
        {
            Debug.Log("hit rockks");
            turtls.speed = 0;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "rockks" && turtls.ride == false)
        {
            turtls.speed = 2;
        }
    }
}
 
 