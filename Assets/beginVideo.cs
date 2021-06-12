using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using FMODUnity;
public class beginVideo : MonoBehaviour
{
    VideoPlayer player;
    public StudioEventEmitter pl;
    public GameObject sd,black;
    public pcontroller playerControls;
    private void Start()
    {
        player = GetComponent<VideoPlayer>();
    }
    private void Update()
    { 
        player.loopPointReached += finishgame;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Endvideo();
        }
    }
    void Endvideo()
    {
        Debug.Log("EINDIG DIE VIDEO");
        playerControls.enabled = true;
        //SceneManager.LoadScene(2);
        pl.enabled = true;
        //Destroy(this.gameObject.transform.parent);
       // Destroy(sd);
        sd.SetActive(false);
        //Destroy(black);
        black.SetActive(false);
        this.gameObject.SetActive(false);
        //Destroy(this.gameObject);
        
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
