using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class beginVideo : MonoBehaviour
{
    private void Update()
    {
        VideoPlayer player = GetComponent<VideoPlayer>();
        player.loopPointReached += finishgame;
    }
    void Endvideo()
    {
        Debug.Log("EINDIG DIE VIDEO");
        SceneManager.LoadScene("playtestv2");
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
