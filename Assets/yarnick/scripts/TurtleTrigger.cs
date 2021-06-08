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
    public GameObject player;
    private Vector3 pos;
    public bool mounted;
    public RouteFollow turtlecontrol;
    // Start is called before the first frame update
    void Start()
    {
        oldParent = player.transform.parent;
        oldScale = player.transform.localScale;
        //pos = new Vector3(this.transform.position.x, this.transform.position.y + 0.2f, this.transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(this.transform.position.x, this.transform.position.y + 0.3f, this.transform.position.z);
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
            player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            player.transform.parent = this.transform.parent;
            player.transform.position = this.transform.position;
            player.GetComponent<pcontroller>().enabled = false;
            tut = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ride == false)
        {
            speed = 2;
            maincam.gameObject.SetActive(false);
            turtlecam.gameObject.SetActive(true);
            buddy.GetComponent<BuddyMovement>().cam = turtlecam.gameObject;
            player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            player.GetComponent<pcontroller>().enabled = false;
            player.GetComponent<Animator>().SetBool("frontmovement", false);
            player.GetComponent<Animator>().SetBool("backmovement", false);
            player.GetComponent<Animator>().SetBool("sidemovement", false);
            player.GetComponent<Animator>().SetBool("backjump", false);
            player.GetComponent<Animator>().SetBool("sidejump", false);
            player.GetComponent<Animator>().SetBool("viool", true);
            //player.GetComponent<Animator>().SetBool("viool", false);
            player.transform.parent = this.transform.parent;
            player.transform.position = pos;
            player.transform.eulerAngles = new Vector3(0,0,0);
            tut = true;
            mounted = true;
            turtlecontrol.mounted = true;
        }
            if (other.gameObject.tag == "end" && ride == false)
        {
            //speed = 0; 
            maincam.gameObject.SetActive(true);
            turtlecam.gameObject.SetActive(false);
            buddy.GetComponent<BuddyMovement>().cam = maincam.gameObject;
            ride = true;
            player.GetComponent<pcontroller>().enabled = true;
            player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ride == true)
        {
            player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            player.transform.parent = oldParent; 
            tut = false;
            turtlecontrol.mounted = false ;
            mounted = false;
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
