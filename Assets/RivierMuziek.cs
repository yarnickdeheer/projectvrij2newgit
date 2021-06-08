using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class RivierMuziek : MonoBehaviour
{
    public StudioEventEmitter backgroundMusic;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            backgroundMusic.SetParameter("Situatie", 2, false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            backgroundMusic.SetParameter("Situatie", 0, false);
        }
    }
}
