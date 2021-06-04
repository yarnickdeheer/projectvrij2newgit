using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleTrigger : MonoBehaviour
{
    public RouteFollow turtle;
    private Transform oldParent;
    bool tut;
    Vector3 oldScale;
    bool ride;
    public GameObject buddy;
    public Camera maincam, turtlecam;

    // Start is called before the first frame update
    void Start()
    {
        oldParent = this.transform.parent;
        oldScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (tut == true)
        {
            this.transform.localScale = oldScale;
           
        }
        if (turtle.gameObject.transform.position == turtle.routes[4].GetChild(3).transform.position)
        {
            Debug.Log("end of the ride sadge");
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "turtle" && ride == false)
        {
            maincam.gameObject.SetActive(false);
            turtlecam.gameObject.SetActive(true);
            buddy.GetComponent<BuddyMovement>().cam = turtlecam.gameObject;
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            this.transform.parent = other.transform.parent;
            this.transform.position = other.transform.position;
            turtle.speedInDistance = 2;
            tut = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "end" && ride == false)
        {
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
        if (other.gameObject.tag == "turtle" && ride == true)
        {
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            this.transform.parent = oldParent;
            tut = false;
        }
    }
}
