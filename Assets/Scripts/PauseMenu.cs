using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject userInterface;
    public GameObject puaseMenu;
    public void Pause()
    {
        userInterface.SetActive(false);
        puaseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }
    public void Resume()
    {
        Time.timeScale = 1f;
        userInterface.SetActive(true);
        puaseMenu.SetActive(false);
        isPaused = false;
        
    }
    private void Update()
    {
        if(Input.GetAxis("pause") == 1 && !(isPaused))
        {
            Pause();
        }
    }
}
