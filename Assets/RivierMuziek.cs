using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class RivierMuziek : MonoBehaviour
{
    public StudioEventEmitter backgroundMusic;
    public StudioEventEmitter normaalVoetjes;
    public StudioEventEmitter stamVoetjes;
    pcontroller playerControl;

    private void Start()
    {
        playerControl = FindObjectOfType<pcontroller>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            backgroundMusic.SetParameter("Situatie", 2, false);
            //playerControl.footsteps = stamVoetjes;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            backgroundMusic.SetParameter("Situatie", 0, false);
            //playerControl.footsteps = normaalVoetjes;
        }
    }
}
