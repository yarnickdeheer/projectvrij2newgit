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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mounted == true && tijd > 0)
        {
            // start timer when mounted
            tijd -= Time.deltaTime;
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

        if (mounted == true)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                goat.transform.position = new Vector3(pos[i].position.x, pos[i].position.y + 0.2f, pos[i].position.z);
            }

                if (Input.GetKeyDown(KeyCode.Alpha1) && pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsRU[0] != null)
            {
                // rechts boven
                int f = pos[i].gameObject.GetComponent<GoatPlatform>().cost;
                tijd -= f;
                pos.Add(pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsRU[0].transform);
                i++;
                goat.transform.position = new Vector3(pos[i].position.x, pos[i].position.y + 0.2f, pos[i].position.z);
                tijd = 5;

            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsLU[0] != null)
            {
                // links boven

                int f = pos[i].gameObject.GetComponent<GoatPlatform>().cost;
                tijd -= f;
                pos.Add(pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsLU[0].transform);
                i++;
                goat.transform.position = new Vector3(pos[i].position.x, pos[i].position.y + 0.2f, pos[i].position.z);
                tijd = 5;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsRD[0] != null)
            {
                // rechts onder

                int f = pos[i].gameObject.GetComponent<GoatPlatform>().cost;
                tijd -= f;
                pos.Add(pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsRD[0].transform);
                i++;
                goat.transform.position = new Vector3(pos[i].position.x, pos[i].position.y + 0.2f, pos[i].position.z);
                tijd = 5;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsLD[0] != null)
            {
                // links onder
                int f = pos[i].gameObject.GetComponent<GoatPlatform>().cost;
                tijd -= f;
                pos.Add(pos[i].gameObject.GetComponent<GoatPlatform>().connectingPlatformsLD[0].transform);
                i++;
                goat.transform.position = new Vector3(pos[i].position.x, pos[i].position.y + 0.2f, pos[i].position.z);
                tijd = 5;
            }

        }
        if ( pos[i].gameObject.GetComponent<GoatPlatform>().end == true && i != 0 )
            {
            if (top == true)
            {
                goatEnd = pos[i];
                mounted = false;
                player.transform.parent = null;
                cam.SetActive(false);
                pcam.SetActive(true);
                player.GetComponent<pcontroller>().enabled = true;
                player.transform.position = new Vector3(pos[i].position.x, pos[i].position.y + 0.2f, pos[i].position.z);
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
                timer.text = tijd.ToString(" ");
                tijd = 5;
                top = false;
                pos.Clear();
                pos.Add(goatStart);
                i = 0;

            }
            else
            {
                goatEnd = pos[i];
                mounted = false;
                player.transform.parent = null;
                cam.SetActive(false);
                pcam.SetActive(true);
                player.GetComponent<pcontroller>().enabled = true;
                player.transform.position = new Vector3(pos[i].position.x, pos[i].position.y + 0.2f, pos[i].position.z);
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
                timer.text = tijd.ToString(" ");
                tijd = 5;
                top = true;
                pos.Clear();
                pos.Add(goatEnd);
                i = 0;
            }
          
        }
        
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
                player.GetComponent<pcontroller>().enabled = false;
                
                player.transform.parent = goat.transform;
                player.transform.localPosition = new Vector3(0, goat.transform.position.y + 90, 0);

                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
                tijd = 5;
            }
        }
    }

}
