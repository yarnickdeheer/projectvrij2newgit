using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public Vector3 spawnLoc;
    // Start is called before the first frame update
    public RouteFollow turtle;
    public TurtleTrigger turtls;
    void Awake()
    {
        spawnLoc = transform.parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "rockks" && turtls.ride == false)
        {

            //respawn
            transform.parent.transform.position = spawnLoc;

            //Debug.Log("hit rockks");
            //turtls.speed = 0;
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //if (other.gameObject.tag == "rockks" && turtls.ride == false)
    //{
    //    turtls.speed = 2;
    //}
    //}

    //private void OnCollisionstay(Collision collision)
    //{
    //    Debug.Log("hit anything" + " " + collision.gameObject.tag +"  dasda" + turtls.ride);

    //    if (collision.gameObject.tag == "rockks" && turtls.ride == false)
    //    {
    //        Debug.Log("hit rockks");
    //        turtls.speed = 0;
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "rockks" && turtls.ride == false)
    //    {
    //        turtls.speed = 2;
    //    }
    //}
}

