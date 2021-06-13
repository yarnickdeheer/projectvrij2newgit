using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDeath : MonoBehaviour
{
    public Transform spawnLoc;

    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("EJUK<RHKLEJFVJHEGSRJFDVH");
            while (other.transform.position != spawnLoc.position)
            {
                //other.GetComponent<pcontroller>().enabled = false;
                other.transform.position = spawnLoc.position;
            }
            //other.GetComponent<pcontroller>().enabled = true;
        }
    }
}
