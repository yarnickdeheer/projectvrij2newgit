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

        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && !pauseIsOn)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            pauseIsOn = true;
        } 
        else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && pauseIsOn)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            pauseIsOn = false;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        pauseIsOn = false;
    }
}
