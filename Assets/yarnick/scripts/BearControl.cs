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

    public Animator bearfront, bearback, bearsideL, bearsideR;
    int DBpotential;
    public bool inrange, destroy;



    private CleanNotes notes;

    //public int[] forwards;
    //public int[] backwards;
    public int[] rightup;
    private List<int> privateNoteList;

    void Start()
    {
        privateNoteList = new List<int>();
        notes = FindObjectOfType<CleanNotes>();
    }

    // Update is called once per frame
    void Update()
    {


        if (notes.checkNoteInput() > -1)
            privateNoteList.Add(notes.checkNoteInput());

        //cleanLastPlayedNotes(privateNoteList);
    

        int correctInput = goThroughOptions(new int[][] { rightup});
        if (inrange == true)
        {
            switch (correctInput)
            {
                case -1:
                    break;

                case 0:
                    //follow
                    bearback.SetBool("walk", true);
                    bearsideL.SetBool("walk", true);
                    bearsideR.SetBool("walk", true);
                    bearfront.SetBool("walk", true);
                    bearsideL.SetBool("pull", false);
                    bearsideR.SetBool("pull", false);
                    bearsideL.SetBool("push", false);
                    bearsideR.SetBool("push", false);
                    bear.speed = 3.5f;
                    Destroy(ss);
                    ss = Instantiate(target, target.transform.position, Quaternion.identity);

                    bear.gameObject.GetComponent<Patrol>().target = ss.transform;
                    bear.gameObject.GetComponent<MeshRenderer>().material = green;
                    jump.transform.localScale = new Vector3(1, 5, 1);
                    jump.tag = "ground";
                    break;

            }
        }






        //    if (DBpotential ==4)
        //{
        //    destroy = true;
        //}
        //else
        //{
        //    destroy = false;
        //}
        //if (Input.GetKeyDown(KeyCode.E) && inrange == true)
        //{
        //    bear.speed = 3.5f;
        //    Destroy(ss);
        //    ss =  Instantiate(target, target.transform.position, Quaternion.identity);
            
        //    bear.gameObject.GetComponent<Patrol>().target = ss.transform;
        //    bear.gameObject.GetComponent<MeshRenderer>().material = green;
        //    jump.transform.localScale = new Vector3(1, 5, 1);
        //    jump.tag = "ground";
        //}
        //if (Input.GetKeyDown(KeyCode.R) && inrange == true)
        //{
        //    // jump active
        //    bear.gameObject.GetComponent<MeshRenderer>().material = red;
        //    jump.transform.localScale = new Vector3(1,1,1);
        //    jump.tag = "ground";
        //}
        //if (Input.GetKeyDown(KeyCode.V) && destroy == true)
        //{
        //    DB.GetComponent<Patrol>().target = DBtarget.transform;
        //    DB.GetComponent<DestroyBear>().target = DBtarget;
        //}

        if (privateNoteList.Count == 4)
        {
            cleanLastPlayedNotes(privateNoteList);
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
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bear")
        {
            Debug.Log("bbbb" + other.gameObject.name);
            inrange = true;
            ss.GetComponent<BearTarget>().bear = other.gameObject.GetComponent<NavMeshAgent>();
            bear = other.gameObject.GetComponent<NavMeshAgent>();

            bearfront = other.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Animator>();
            bearback = other.gameObject.transform.GetChild(4).GetChild(2).GetComponent<Animator>();
            bearsideL= other.gameObject.transform.GetChild(4).GetChild(1).GetComponent<Animator>();
            bearsideR = other.gameObject.transform.GetChild(4).GetChild(3).GetComponent<Animator>();


        }
        else if (other.gameObject.tag == "destroybear")
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




    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "bear")
        {
         
            ss.GetComponent<BearTarget>().bear = other.gameObject.GetComponent<NavMeshAgent>();
            bear = other.gameObject.GetComponent<NavMeshAgent>();

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
    
}
