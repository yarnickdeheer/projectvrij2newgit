using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Material red;
    public Material green;
    public NavMeshAgent bear;
    public GameObject target;
    public GameObject ss;
    public GameObject jump;
    private GameObject DB,DBtarget;
    int DBpotential;
    public bool inrange, destroy;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {









        if (DBpotential ==4)
        {
            destroy = true;
        }
        else
        {
            destroy = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && inrange == true)
        {
            bear.speed = 3.5f;
            Destroy(ss);
            ss =  Instantiate(target, target.transform.position, Quaternion.identity);
            bear.gameObject.GetComponent<Patrol>().target = ss.transform;
            bear.gameObject.GetComponent<MeshRenderer>().material = green;
            jump.transform.localScale = new Vector3(1, 5, 1);
            jump.tag = "ground";
        }
        if (Input.GetKeyDown(KeyCode.R) && inrange == true)
        {
            // jump active
            bear.gameObject.GetComponent<MeshRenderer>().material = red;
            jump.transform.localScale = new Vector3(1,1,1);
            jump.tag = "ground";
        }
        if (Input.GetKeyDown(KeyCode.V) && destroy == true)
        {
            DB.GetComponent<Patrol>().target = DBtarget.transform;
            DB.GetComponent<DestroyBear>().target = DBtarget;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bear")
        {
            inrange = true;
        } else if (other.gameObject.tag == "destroybear")
        {
            DB = other.gameObject;
            DBpotential += 1;
        }
        else if (other.gameObject.tag == "log")
        {
            DBpotential += 1;
            DBtarget = other.gameObject;
            
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "bear")
        {
            inrange = false;
        }
        else if (other.gameObject.tag == "destroybear")
        {
            DB = null;
            DBpotential -= 1;
        }
        else if (other.gameObject.tag == "log")
        {
            DBpotential -= 1;
            DBtarget = null;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "inviroment")
        {
            this.gameObject.transform.GetChild(0).GetComponent<BearPushPull>().envo = true;
        }
    }
}
