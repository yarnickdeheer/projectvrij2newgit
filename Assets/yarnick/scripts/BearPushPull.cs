using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
public class BearPushPull : MonoBehaviour
{
    private Vector3 dir;
    public float force;
    //push pull
    //public GameObject Left, Right, Forward, Back;
    public float speed;
    CharacterController Controller;
    bool pushpul;
    Vector3 tg;
    GameObject tgobject;
    public bool envo;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.gameObject.name);
        Controller = this.gameObject.transform.parent.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pushpul == true)
        {
            this.gameObject.transform.parent.transform.position = Vector3.MoveTowards(this.gameObject.transform.parent.transform.position, new Vector3(tg.x, this.gameObject.transform.parent.transform.position.y, tg.z), speed * Time.deltaTime);

        }
        //Debug.Log(this.gameObject.transform.parent.transform.position +"  ======  "+ tg);
        if (this.gameObject.transform.parent.transform.position == tg && pushpul==true || envo==true )
        {
            Debug.Log(tgobject.transform.parent.gameObject);
            tgobject.transform.parent = this.gameObject.transform.parent.parent;
            pushpul = false;
            envo = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
         
        //red is forward
        if (other.gameObject.tag=="moveable")
        {
            Debug.Log("PUSH DIE SHIEEET" + other.gameObject.name);
            dir = other.transform.position - transform.position;
            //dir = dir.normalized;
            if (other.gameObject.name == "down")
            {
                Debug.Log("PUSH DIE SHIEEET");
                //other.gameObject.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                //other.gameObject.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
                if (Input.GetKeyDown(KeyCode.B))
                {
                   // other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * force);//down coll
                                                                                                                    // pushpull(other.gameObject);
                    pushpull(0, other.gameObject);

                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * force);//down coll


                    pushpull(1, other.gameObject);

                }
            }
            if (other.gameObject.name == "top")
            {
                Debug.Log("PUSH DIE SHIEEET");
                if (Input.GetKeyDown(KeyCode.B))
                {
                    speed = speed * -1;
                    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * (force * -1));//up coll
                    pushpull(0, other.gameObject);

                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * force);//down coll


                    pushpull(1, other.gameObject);

                }
            }

            if (other.gameObject.name == "left")
            {
                Debug.Log("PUSH DIE SHIEEET");
                if (Input.GetKeyDown(KeyCode.B))
                {
                    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.right * force);//rightcoll
                    pushpull(0, other.gameObject);
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * force);//down coll


                    pushpull(1, other.gameObject);

                }
            }

            if (other.gameObject.name == "right")
            {
                Debug.Log("PUSH DIE SHIEEET");
                if (Input.GetKeyDown(KeyCode.B))
                {
                    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.right * (force * -1));//left coll
                    pushpull(0,other.gameObject);
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * force);//down coll


                    pushpull(1, other.gameObject);

                }   
            }
           
            
          
        }
        
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "down" || other.gameObject.name == "top" || other.gameObject.name == "left" || other.gameObject.name == "right")
        {

            other.gameObject.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            other.gameObject.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
        }
    }
    public void pushpull(int pp,GameObject other)
    {

        if (pp == 0)
        {
            Debug.Log("pppp pulllling");
            tg = new Vector3(other.transform.GetChild(0).transform.position.x, this.gameObject.transform.parent.transform.position.y, other.transform.GetChild(0).transform.position.z);

        }
        else if (pp == 1)
        {
            Debug.Log("pppp pushhing");
            tg = new Vector3(other.transform.GetChild(1).transform.position.x, this.gameObject.transform.parent.transform.position.y, other.transform.GetChild(1).transform.position.z);

        }




        tgobject = other.transform.parent.gameObject;
        other.transform.parent.parent = this.gameObject.transform.parent.transform;
        float sp = speed;
       // Debug.Log(pos.transform.position + " == " + pos.transform.localPosition);
        
       // Destroy(this.gameObject.transform.parent.gameObject.GetComponent<Patrol>().target.gameObject);
       //this.gameObject.transform.parent.gameObject.GetComponent<NavMeshAgent>().speed = 2;
       // this.gameObject.transform.parent.gameObject.GetComponent<Patrol>().target = pos.transform;
       //if (this.gameObject.transform.parent.gameObject.transform == pos.transform)
       //{
       //    Debug.Log("ahhhhhhhhhhhhhhhhhhhhhhh");
       //    this.gameObject.transform.parent.gameObject.GetComponent<NavMeshAgent>().speed = 0;
       //}
       // this.gameObject.transform.parent.transform.position = Vector3.MoveTowards(this.gameObject.transform.parent.transform.position , pos.transform.position, speed * Time.deltaTime);
        float Horizontal = speed;
        float Vertical = speed;
       //while (this.gameObject.transform.parent.gameObject.GetComponent<NavMeshAgent>().speed  > 0)
       //{
       //     this.gameObject.transform.parent.gameObject.GetComponent<NavMeshAgent>().speed -= 0.1f;
       //}
        speed = sp;
        pushpul = true;
    }
}
