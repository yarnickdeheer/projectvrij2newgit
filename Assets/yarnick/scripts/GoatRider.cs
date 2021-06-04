using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoatRider : MonoBehaviour
{

    //goat
    public GameObject goat;

    public GameObject cam;
    public bool mounted;
    public  List<Transform> pos;
    private int i;

    public Transform goatStart;
    public Transform goatEnd;
    //player
    public GameObject pcam, player;

    //timer 
    public float tijd;
    public Text timer;
    public bool top;

    private Transform oldParent;




    private CleanNotes notes;

    //public int[] forwards;
    //public int[] backwards;
    public int[] rightup;
    public int[] leftup;

    public int[] rightdown;
    public int[] leftdown;
    private List<int> privateNoteList;

    // Start is called before the first frame update
    void Start()
    {
        privateNoteList = new List<int>();
        notes = FindObjectOfType<CleanNotes>();
        oldParent = this.transform.parent;
    }




    // Update is called once per frame
    void Update()
    {
   

        if (mounted == true && tijd > 0)
        {
            // start timer when mounted
            //tijd -= Time.deltaTime;
            timer.text = tijd.ToString("0");

        }else if (mounted == true && tijd < 0)
        {
            // die
            Debug.Log("TIJD IS OM JE HEBT HET NIET GEHAALD");
            goat.transform.position = new Vector3(goatStart.position.x, goatStart.position.y + 0.2f, goatStart.position.z);

            mounted = false;
            player.transform.parent = null;
            cam.SetActive(false);
            pcam.SetActive(true);
            player.GetComponent<pcontroller>().enabled = true;
            player.transform.position = new Vector3(goatStart.position.x, goatStart.position.y + 0.2f, goatStart.position.z + 1);
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
            tijd = 5;
          
            if (top == true)
            {

                goat.transform.position = new Vector3(goatEnd.position.x, goatEnd.position.y + 0.2f, goatEnd.position.z);
                player.transform.position = new Vector3(goatEnd.position.x, goatEnd.position.y + 0.2f, goatEnd.position.z + 1);
                pos.Clear();
                pos.Add(goatEnd);
                i = 0;
            }
            else if (top == false)
            {
                pos.Clear();
                pos.Add(goatStart);
                i = 0;
            }

        }





        if (notes.checkNoteInput() > -1)
            privateNoteList.Add(notes.checkNoteInput());

        //cleanLastPlayedNotes(privateNoteList);
        // Debug.Log(privateNoteList[0]);



        int correctInput = goThroughOptions(new int[][] { rightup, leftup, rightdown, leftdown });
        if (mounted == true)
        {
            switch (correctInput)
            {
                
                case -1:
                    break;

                case 0:
                    //go right
                  
                    if (pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsRU.Length != 0)
                    {
                        // rechts boven
                        MoveToRUPlatform(pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsRU[0].transform);
                        //a++;
                    }
                    else
                    {
                        break;
                    }     
                    //cleanLastPlayedNotes(privateNoteList);

                    break;

                case 1:
                    //go left
                    if (pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsLU.Length != 0)
                    {
                        // links boven
                        MoveToRUPlatform(pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsLU[0].transform);
                    }

                    else
                    {
                        break;
                    }
                    //cleanLastPlayedNotes(privateNoteList);
                    break;

                case 2:
                    //    //go right
                    if (pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsRD.Length != 0)
                    {
                        // rechts onder
                        MoveToRUPlatform(pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsRD[0].transform);
                    }

                    else
                    {
                        break;
                    }
                    //cleanLastPlayedNotes(privateNoteList);
                    break;

                case 3:
                    //    //go left
               
                    if (pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsLD.Length != 0)
                    {
                        // links onder
                        MoveToRUPlatform(pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsLD[0].transform);
                    }

                    else
                    {
                        break; 
                    }
                    //cleanLastPlayedNotes(privateNoteList);
                    break;

            }

            if(privateNoteList.Count == 4)
            {
                cleanLastPlayedNotes(privateNoteList);
            }


        }








        //if (mounted == true)
        //{

        //    if (Input.GetKeyDown(KeyCode.Alpha1) && pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsRU[0] != null)
        //    {
        //        // rechts boven
        //        MoveToRUPlatform(pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsRU[0].transform);
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Alpha2) && pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsLU[0] != null)
        //    {
        //        // links boven
        //        MoveToRUPlatform(pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsLU[0].transform);
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Alpha3) && pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsRD[0] != null)
        //    {
        //        // rechts onder
        //        MoveToRUPlatform(pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsRD[0].transform);
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Alpha4) && pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsLD[0] != null)
        //    {
        //        // links onder
        //        MoveToRUPlatform(pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsLD[0].transform);
        //    }

        //}
        if ( pos[i].gameObject.GetComponent<GoatPlatform>().end == true && i != 0 )
            {
            if (top == true)
            {
                goatEnd = pos[i];
                mounted = false;
                this.transform.parent = oldParent;
                cam.SetActive(false);
                pcam.SetActive(true);
                player.GetComponent<pcontroller>().enabled = true; // deze is het niet
                player.transform.position = new Vector3(pos[i].position.x, pos[i].position.y, pos[i].position.z);//deze is het niet
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                timer.text = tijd.ToString(" ");
                tijd = 5;
                top = false;
                pos.Clear();
                pos.Add(goatStart);
                i = 0;

                //maincam.gameObject.SetActive(false);
                //turtlecam.gameObject.SetActive(true);
                //buddy.GetComponent<BuddyMovement>().cam = turtlecam.gameObject;
                //this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                //this.transform.parent = other.transform.parent;
                //this.transform.position = other.transform.position;
                //if (other.gameObject.tag == "turtle" && ride == true)
                //{
                //    this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                //    this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                //    this.transform.parent = oldParent;
                //    tut = false;
                //}
            }
            else
            {
                goatEnd = pos[i];
                mounted = false;
                player.transform.parent = null;
                cam.SetActive(false);
                pcam.SetActive(true);
                player.GetComponent<pcontroller>().enabled = true;//deze is het niet
                player.transform.position = new Vector3(pos[i].position.x, pos[i].position.y + 0.2f, pos[i].position.z);//deze is het niet
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                timer.text = tijd.ToString(" ");
                tijd = 5;
                top = true;
                pos.Clear();
                pos.Add(goatEnd);
                i = 0;
            }
          
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
    private void MoveToRUPlatform(Transform platformTransform)
    {
        int f = pos[i].gameObject.GetComponent<GoatPlatform>().cost;
        tijd -= f;
        pos.Add(platformTransform);
        i++;
        goat.transform.position = new Vector3(pos[i].position.x, pos[i].position.y + 0.2f, pos[i].position.z);
        tijd = 5;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetKeyDown(KeyCode.G) && mounted ==false)
            {
                //mount
                mounted = true;
                cam.SetActive(true);
                pcam.SetActive(false);
                player.GetComponent<pcontroller>().enabled = false;// deze is het niet

                player.transform.parent = goat.transform;
                player.transform.localPosition = new Vector3(0, goat.transform.position.y + 90, 0);//deze is het niet

                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
                tijd = 5;
            }
        }
    }

}
