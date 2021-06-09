using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class BearMusicController : MonoBehaviour
{
    public int whichSituation;
    public StudioEventEmitter backgroundMusic;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //start beer muziek
            backgroundMusic.SetParameter("Situatie", whichSituation, false);
        }
    }
}
