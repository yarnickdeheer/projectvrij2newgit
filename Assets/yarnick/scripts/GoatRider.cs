using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
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
    //public Text timer;
    public bool top;

    private Transform oldParent;


    public Animator goatAnim;

    private CleanNotes notes;

    //public int[] forwards;
    //public int[] backwards;
    public int[] rightup;
    public int[] leftup;

    public int[] rightdown;
    public int[] leftdown;
    private List<int> privateNoteList;

    public StudioEventEmitter backgroundMusic;

    [SerializeField]

    public Transform[] routes;

    private float tParam;

    private Vector3 objectPosition;

    private float speedModifier;
    public float speedInDistance;

    private bool coroutineAllowed;
    public SpriteRenderer alto;

    public StudioEventEmitter landing;



    public RawImage ui;
    public Texture goatUI;
    bool jumpdone;

    // Start is called before the first frame update
    void Start()
    {
        landing = GetComponent<StudioEventEmitter>();
        privateNoteList = new List<int>();
        notes = FindObjectOfType<CleanNotes>();
        oldParent = this.transform.parent;

        tParam = 0f;
        speedModifier = 0.5f;
        coroutineAllowed = true;

    }




    // Update is called once per frame
    void Update()
    {
        if (privateNoteList.Count >= 4)
        {

            cleanLastPlayedNotes(privateNoteList);
            //cleanLastPlayedNotes(notes.PlayedNotes);
        }

        if (mounted == true && tijd > 0)
        {
            // start timer when mounted
            //tijd -= Time.deltaTime;
           // timer.text = tijd.ToString("0");

        }else if (mounted == true && tijd < 0)
        {
            // die
            Debug.Log("TIJD IS OM JE HEBT HET NIET GEHAALD");
            goat.transform.position = new Vector3(goatStart.position.x, goatStart.position.y + 0.2f, goatStart.position.z);

            mounted = false;
            backgroundMusic.SetParameter("Situatie", 0, false);
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

        if (mounted == true && coroutineAllowed)
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
                        goatAnim.gameObject.GetComponent<SpriteRenderer>().flipX = true;
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
                        goatAnim.gameObject.GetComponent<SpriteRenderer>().flipX = false;
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

            if(privateNoteList.Count >= 4)
            {
                //cleanLastPlayedNotes(notes.PlayedNotes);

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
            privateNoteList.Clear();
            //notes.PlayedNotes.Clear();
            if (top == true && jumpdone == true)
            {
                ui.texture = null;
                var tempColor = ui.color;
                tempColor.a = 0f;
                ui.color = tempColor;
                goatAnim.SetBool("mounted", false);
                goatAnim.SetBool("jump", false);
                goatEnd = pos[i];
                mounted = false;
                backgroundMusic.SetParameter("Situatie", 0, false);
                this.transform.parent = oldParent;
                cam.SetActive(false);
                pcam.SetActive(true);
                player.GetComponent<pcontroller>().enabled = true; // deze is het niet
                player.transform.position = new Vector3(pos[i].position.x, pos[i].position.y, pos[i].position.z);//deze is het niet
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                player.GetComponent<SpriteRenderer>().enabled = true;
              //  timer.text = tijd.ToString(" ");
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
            else if(jumpdone == true)
            {
                ui.texture = null;
                var tempColor = ui.color;
                tempColor.a = 0f;
                ui.color = tempColor;
                goatEnd = pos[i];
                mounted = false;
                backgroundMusic.SetParameter("Situatie", 0, false);
                player.transform.parent = null;
                goatAnim.SetBool("mounted", false);
                goatAnim.SetBool("jump", false);
                cam.SetActive(false);
                pcam.SetActive(true);
                player.GetComponent<SpriteRenderer>().enabled = true;
                player.GetComponent<pcontroller>().enabled = true;//deze is het niet
                player.transform.position = new Vector3(pos[i].position.x, pos[i].position.y + 0.2f, pos[i].position.z);//deze is het niet
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
               // timer.text = tijd.ToString(" ");
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
        while (privateNoteList.Count >= 4)
        {

            //notes.PlayedNotes.Clear() ;
            privateNoteList.RemoveAt(0); privateNoteList.RemoveAt(0);
        }
    }
    private void MoveToRUPlatform(Transform platformTransform)
    {
        int f = pos[i].gameObject.GetComponent<GoatPlatform>().cost;
        tijd -= f;
        pos.Add(platformTransform);
        i++;
        goatAnim.SetBool("jump", true);
        Vector3 targetLoc = new Vector3(pos[i].position.x, pos[i].position.y + 0.2f, pos[i].position.z);
        tijd = 5;
        StartCoroutine(GoatByTheRoute(createBezierCurve(goat.transform.position, goat.transform.position + new Vector3(0,1,0), targetLoc + new Vector3(0,1,0), targetLoc), targetLoc.z));

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (mounted == false && top == false)
            {
                //mount
                var tempColor = ui.color;
                tempColor.a = 1f;
                ui.color = tempColor;
                ui.texture = goatUI;
                alto.enabled = false;
                player.GetComponent<SpriteRenderer>().enabled = false;
                goatAnim.SetBool("mounted", true);
                mounted = true;
                backgroundMusic.SetParameter("Situatie", 1, false);
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

    Transform createBezierCurve(Vector3 pos1, Vector3 pos2, Vector3 pos3, Vector3 pos4)
    {
        GameObject emptyObject = new GameObject();
        GameObject routeParent = Instantiate(emptyObject, pos1, new Quaternion(0, 0, 0, 0));
        GameObject Transform1 = Instantiate(emptyObject, pos1, new Quaternion(0, 0, 0, 0), routeParent.transform);
        GameObject Transform2 = Instantiate(emptyObject, pos2, new Quaternion(0, 0, 0, 0), routeParent.transform);
        GameObject Transform3 = Instantiate(emptyObject, pos3, new Quaternion(0, 0, 0, 0), routeParent.transform);
        GameObject Transform4 = Instantiate(emptyObject, pos4, new Quaternion(0, 0, 0, 0), routeParent.transform);

        routeParent.AddComponent<Route>();
        Route newRoute = routeParent.GetComponent<Route>();
        newRoute.controlPoints = new Transform[4] { Transform1.transform, Transform2.transform, Transform3.transform, Transform4.transform };

        return routeParent.transform;
    }

    private IEnumerator GoatByTheRoute(Transform route, float zPos)
    {
        jumpdone = false;
        coroutineAllowed = false;

        Vector2 p0 = route.GetChild(0).position;
        Vector2 p1 = route.GetChild(1).position;
        Vector2 p2 = route.GetChild(2).position;
        Vector2 p3 = route.GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;
            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;
            transform.position = new Vector3(objectPosition.x, objectPosition.y, zPos);
            yield return new WaitForEndOfFrame();
        }
        landing.Play();

        tParam = 0f;

        coroutineAllowed = true;
        goatAnim.SetBool("jump", false);
        jumpdone = true;
    }

}
