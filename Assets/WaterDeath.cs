using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDeath : MonoBehaviour
{
    public Transform spawnLoc;

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("EJUK<RHKLEJFVJHEGSRJFDVH");
        if(other.gameObject.tag == "Player")
        {
            other.transform.position = spawnLoc.position;
        }
    }
}
