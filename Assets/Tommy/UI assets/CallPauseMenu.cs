using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPauseMenu : MonoBehaviour
{
    public bool pauseIsOn;
    public GameObject PauseMenu;


    // Update is called once per frame
    void Update()
    {
        
        PauseMenu.SetActive(pauseIsOn);

        if (Input.GetKeyDown(KeyCode.Escape) && !pauseIsOn)
        {
            Time.timeScale = 0;
            pauseIsOn = true;
        } 
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseIsOn)
        {
            Time.timeScale = 1;
            pauseIsOn = false;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseIsOn = false;
    }
}
