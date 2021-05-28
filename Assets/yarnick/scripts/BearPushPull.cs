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
        Debug.Log(this.gameObject.transform.parent.transform.position +"  ======  "+ tg);
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
                if (Input.GetKeyDown(KeyCode.B))
                {
                    other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * force);//down coll
                    
                    
                   // pushpull(other.gameObject);

                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * force);//down coll


                    pushpull(other.gameObject);

                }
            }
            if (other.gameObject.name == "top")
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    speed = speed * -1;
                    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * (force * -1));//up coll
                    pushpull(other.gameObject);

                }
            }

            if (other.gameObject.name == "left")
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.right * force);//rightcoll
                    pushpull(other.gameObject);
                }
            }

            if (other.gameObject.name == "right")
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.right * (force * -1));//left coll
                    pushpull(other.gameObject);
                }
            }
           
            
          
        }
       
    }
    public void pushpull(GameObject pos)
    {
        tg = new Vector3(pos.transform.GetChild(0).position.x, this.gameObject.transform.parent.transform.position.y, pos.transform.GetChild(0).position.z);
        tgobject = pos.transform.parent.gameObject;
        float sp = speed;
        Debug.Log(pos.transform.position + " == " + pos.transform.localPosition);
        pos.transform.parent.parent = this.gameObject.transform.parent.transform;
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
