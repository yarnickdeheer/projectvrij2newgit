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
    float dist, temp;
    public Animator bearleft, bearright;

    private CleanNotes notes;

    //public int[] forwards;
    //public int[] backwards;
    public int[] rightup;
    public int[] leftup;
    private List<int> privateNoteList;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.gameObject.name);
        Controller = this.gameObject.transform.parent.GetComponent<CharacterController>();

        privateNoteList = new List<int>();
        notes = FindObjectOfType<CleanNotes>();
    }

    // Update is called once per frame
    void Update()
    {


     

        //cleanLastPlayedNotes(privateNoteList);
        Debug.Log(privateNoteList[0]);

       

        if (pushpul == true)
        {
            this.gameObject.transform.parent.transform.position = Vector3.MoveTowards(this.gameObject.transform.parent.transform.position, new Vector3(tg.x, this.gameObject.transform.parent.transform.position.y, tg.z), speed * Time.deltaTime);

            //move();
            
        }
        //Debug.Log(this.gameObject.transform.parent.transform.position +"  ======  "+ tg);
        if (this.gameObject.transform.parent.transform.position == new Vector3(tg.x, this.gameObject.transform.parent.transform.position.y, tg.z) && pushpul==true || envo==true )
        {
            Debug.Log("basinga");
            tgobject.transform.parent = this.gameObject.transform.parent.parent;
            pushpul = false;
            envo = false;
        }

       
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "moveable")
    //    {
    //        if (other.gameObject.name == "down")
    //        {
    //            //-25.953

    //           

    //        }
    //        if (other.gameObject.name == "top")
    //        {
    //            this.gameObject.transform.parent.transform.eulerAngles = new Vector3(this.gameObject.transform.parent.transform.rotation.x, 154.35f, this.gameObject.transform.parent.transform.rotation.z);

    //            //154.35
    //        }
    //        if (other.gameObject.name == "right")
    //        {
    //            StartCoroutine(delay());
                
    //           // this.gameObject.transform.parent.transform.position = other.gameObject.transform.GetChild(0).transform.position;
    //           // this.gameObject.transform.parent.GetComponent<Patrol>().enabled = true;

    //            this.gameObject.transform.parent.transform.eulerAngles = new Vector3(this.gameObject.transform.parent.transform.rotation.x, -116.459f, this.gameObject.transform.parent.transform.rotation.z);
    //            //-116.459


    //        }
    //        if (other.gameObject.name == "left")
    //        {
    //            //64.5
    //            this.gameObject.transform.parent.transform.eulerAngles = new Vector3(this.gameObject.transform.parent.transform.rotation.x, 64.5f, this.gameObject.transform.parent.transform.rotation.z);

    //        }

    //    }

    //    }
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
                Debug.Log("PUSH DIE SHIEEET" + other.gameObject.transform.position);
                this.gameObject.transform.parent.transform.eulerAngles = new Vector3(this.gameObject.transform.parent.transform.rotation.x, -25.953f, this.gameObject.transform.parent.transform.rotation.z);
                if (notes.checkNoteInput() > -1)
                    privateNoteList.Add(notes.checkNoteInput());

                int correctInput = goThroughOptions(new int[][] { rightup, leftup });
                switch (correctInput)
                    {
                        case -1:
                            break;

                        case 0:
                        pushpull(0, other.gameObject);
                        break;
                        case 1:
                        pushpull(1, other.gameObject);
                        break;

                }
                if (privateNoteList.Count >= 4)
                {
                    cleanLastPlayedNotes(privateNoteList);
                }




                ////other.gameObject.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                ////other.gameObject.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
                //if (Input.GetKeyDown(KeyCode.B))
                //{
                //   // other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * force);//down coll
                //                                                                                                    // pushpull(other.gameObject);
                //    pushpull(0, other.gameObject);

                //}
                //if (Input.GetKeyDown(KeyCode.N))
                //{
                //    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * force);//down coll


                //    pushpull(1, other.gameObject);

                //}
            }
            if (other.gameObject.name == "top")
            {
                Debug.Log("PUSH DIE SHIEEET" + other.gameObject.transform.position);
                this.gameObject.transform.parent.transform.eulerAngles = new Vector3(this.gameObject.transform.parent.transform.rotation.x, 154.35f, this.gameObject.transform.parent.transform.rotation.z);

                if (notes.checkNoteInput() > -1)
                    privateNoteList.Add(notes.checkNoteInput());

                int correctInput = goThroughOptions(new int[][] { rightup, leftup });
                switch (correctInput)
                {
                    case -1:
                        break;

                    case 0:

                        pushpull(0, other.gameObject);
                        break;
                    case 1:
                        pushpull(1, other.gameObject);
                        break;

                }
                if (privateNoteList.Count >= 4)
                {
                    cleanLastPlayedNotes(privateNoteList);
                }
                //if (Input.GetKeyDown(KeyCode.B))
                //{
                //   // speed = speed * -1;
                //    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * (force * -1));//up coll
                //    pushpull(0, other.gameObject);

                //}
                //if (Input.GetKeyDown(KeyCode.N))
                //{
                //    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * force);//down coll


                //    pushpull(1, other.gameObject);

                //}
            }

            if (other.gameObject.name == "left")
            {
                Debug.Log("PUSH DIE SHIEEET" + other.gameObject.transform.position);
                //this.gameObject.transform.parent.transform.position = other.gameObject.transform.position;
                this.gameObject.transform.parent.transform.eulerAngles = new Vector3(this.gameObject.transform.parent.transform.rotation.x, 64.5f, this.gameObject.transform.parent.transform.rotation.z);

                if (notes.checkNoteInput() > -1)
                    privateNoteList.Add(notes.checkNoteInput());

                int correctInput = goThroughOptions(new int[][] { rightup, leftup });
                switch (correctInput)
                {
                    case -1:
                        break;

                    case 0:
                   

                        pushpull(0, other.gameObject);
                        break;
                    case 1:
                   
                        pushpull(1, other.gameObject);
                        break;

                }
                if (privateNoteList.Count >= 4)
                {
                    cleanLastPlayedNotes(privateNoteList);
                }
                //Debug.Log("PUSH DIE SHIEEET");
                //if (Input.GetKeyDown(KeyCode.B))
                //{
                //    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.right * force);//rightcoll
                //    pushpull(0, other.gameObject);
                //}
                //if (Input.GetKeyDown(KeyCode.N))
                //{
                //    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * force);//down coll


                //    pushpull(1, other.gameObject);

                //}
            }

            if (other.gameObject.name == "right")
            {

                //Debug.Log("PUSH DIE SHIEEET" + other.gameObject.transform.position);
                this.gameObject.transform.parent.transform.eulerAngles = new Vector3(this.gameObject.transform.parent.transform.rotation.x, -116.459f, this.gameObject.transform.parent.transform.rotation.z);

                if (notes.checkNoteInput() > -1)
                    privateNoteList.Add(notes.checkNoteInput());

                int correctInput = goThroughOptions(new int[][] { rightup, leftup });
                switch (correctInput)
                {
                    case -1:
                        break;

                    case 0:
                        pushpull(0, other.gameObject);
                        break;
                    case 1:
                        pushpull(1, other.gameObject);
                        break;

                //}
                //Debug.Log("PUSH DIE SHIEEET");
                //if (Input.GetKeyDown(KeyCode.B))
                //{
                //    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.right * (force * -1));//left coll
                //    pushpull(0,other.gameObject);
                //}
                //if (Input.GetKeyDown(KeyCode.N))
                //{
                //    //other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * force);//down coll


                //    pushpull(1, other.gameObject);

                }
                if (privateNoteList.Count >= 4)
                {
                    cleanLastPlayedNotes(privateNoteList);
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

    int goThroughOptions(int[][] options)
    {
        for (int k = 0; k < options.Length; k++)
        {
            for (int i = 0; i < privateNoteList.Count; i++)
            {
                if (i > options[k].Length - 2)
                {
                    return k;
                }

                if (options[k][i] != privateNoteList[i])
                {
                    break;
                }
            }
        }

        return -1;
    }

    public void cleanLastPlayedNotes(List<int> played)
    {
        while (privateNoteList.Count == 4)
        {
            privateNoteList.Clear();
        }
    }

    public void pushpull(int pp,GameObject other)
    {

        if (pp == 0)
        {
            bearleft.SetBool("walk", false);
            bearright.SetBool("walk", false);
            bearleft.SetBool("pull", true);
            bearright.SetBool("pull", true);
            Debug.Log("pppp pulllling");
            tg = new Vector3(other.transform.GetChild(0).transform.position.x, this.gameObject.transform.parent.transform.position.y, other.transform.GetChild(0).transform.position.z);

        }
        else if (pp == 1)
        {
            Debug.Log("pppp pushhing");
            bearleft.SetBool("walk", false);
            bearright.SetBool("walk", false);
            bearleft.SetBool("push", true);
            bearright.SetBool("push", true);
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

    public void move()
    {
        temp = Vector3.Distance(this.gameObject.transform.parent.transform.position, new Vector3(tg.x, this.gameObject.transform.parent.transform.position.y, tg.z));


        while (dist >= temp-100)
        {


            dist = Vector3.Distance(this.gameObject.transform.parent.transform.position, new Vector3(tg.x, this.gameObject.transform.parent.transform.position.y, tg.z));
        }
        pushpul = false;
    }

    IEnumerator delay()
    {
       /// this.gameObject.transform.parent.GetComponent<Patrol>().enabled = false;
        yield return new WaitForSeconds(.5f);
    }
}
