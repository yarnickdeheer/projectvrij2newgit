using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleTrigger : MonoBehaviour
{
    public RouteFollow turtle;
    private Transform oldParent;
    bool tut;
    Vector3 oldScale;
    public bool ride;
    public GameObject buddy;
    public Camera maincam, turtlecam;
    public float speed =2;

    // Start is called before the first frame update
    void Start()
    {
        oldParent = this.transform.parent;
        oldScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("speed" +  speed);
        turtle.speedInDistance = speed;
        if (tut == true)
        {
            ///this.transform.localScale = oldScale;
           
        }
        if (turtle.gameObject.transform.position == turtle.routes[3].GetChild(3).transform.position)
        {
            Debug.Log("end of the ride sadge");
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("turtle") && ride == false)
        {
            maincam.gameObject.SetActive(false);
            turtlecam.gameObject.SetActive(true);
            buddy.GetComponent<BuddyMovement>().cam = turtlecam.gameObject;
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            this.transform.parent = other.transform.parent;
            this.transform.position = other.transform.position;
            
            tut = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("turtle") && ride == false)
        {
            speed = 2;
            maincam.gameObject.SetActive(false);
            turtlecam.gameObject.SetActive(true);
            buddy.GetComponent<BuddyMovement>().cam = turtlecam.gameObject;
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            this.transform.parent = other.transform.parent;
            this.transform.position = other.transform.position;

            tut = true;
        }
            if (other.gameObject.tag == "end" && ride == false)
        {
            //speed = 0; 
            maincam.gameObject.SetActive(true);
            turtlecam.gameObject.SetActive(false);
            buddy.GetComponent<BuddyMovement>().cam = maincam.gameObject;
            ride = true;
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("turtle") && ride == true)
        {
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            this.transform.parent = oldParent; 
            tut = false;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "rockks" && ride == true)
    //    {
    //        speed = 0;
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "rockks" && ride == true)
    //    {
    //        speed = 2;
    //    }
    //}
}
