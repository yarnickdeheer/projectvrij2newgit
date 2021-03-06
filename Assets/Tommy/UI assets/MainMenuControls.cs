using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
public class MainMenuControls : MonoBehaviour
{
    public GameObject menu, startvideo;
    public StudioEventEmitter mainaudio;

    public void StartGame()
    {
        Time.timeScale = 1;

        mainaudio.enabled = false;
        startvideo.SetActive(true);
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void BackToMainMenu()
    {
        //SceneManager.LoadSceneAsync(2);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }
}
