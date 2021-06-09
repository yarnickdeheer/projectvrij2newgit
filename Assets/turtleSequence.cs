using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.Video;

public class turtleSequence : MonoBehaviour
{
    public StudioListener listener;
    public StudioEventEmitter DEZEOOKIGUESS;
    public pcontroller controller;
    public GameObject videoParent;

    public GameObject Turtle;

    bool videoIsPlaying;

    private void Update()
    {
        VideoPlayer player = videoParent.GetComponentInChildren<VideoPlayer>();
        player.loopPointReached += finishgame;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //start turtle sequence
            videoIsPlaying = true;
            StartVideo();
            
        }
    }

    void StartVideo()
    {
        Debug.Log("START DIE VIDEO");
        DEZEOOKIGUESS.Stop();
        controller.enabled = false;
        listener.enabled = false;
        videoParent.SetActive(true);
    }

    void Endvideo()
    {
        Debug.Log("EINDIG DIE VIDEO");
        videoIsPlaying = false;
        DEZEOOKIGUESS.Play();
        controller.enabled = true;
        listener.enabled = true;
        videoParent.SetActive(false);
        Turtle.SetActive(true);
        Turtle.GetComponentInChildren<TurtleTrigger>().StartTurtle();
    }

    void finishgame(VideoPlayer player)
    {
        // bf.SetActive(true);
        /// Screen.lockCursor = true;
        /// Cursor.visible = false;
        //controller.enabled = true;

        Endvideo();
        // image.enabled = false;
        Debug.Log("done");

        //  Time.timeScale = 1;
    }
}
