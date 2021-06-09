using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class stamboerijnSound : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (GetComponent<StudioEventEmitter>().IsPlaying() == false)
                GetComponent<StudioEventEmitter>().Play();
        }
    }
}
