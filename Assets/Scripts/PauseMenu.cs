using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    enum State
    {
        pauseMenu,
        optionMenu,
        off
    }

    private State _state = State.off;
    
    public GameObject userInterface;
    public GameObject pauseMenu;
    public GameObject optionMenu;
    public void Pause()
    {
        userInterface.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        _state = State.pauseMenu;

    }
    public void Resume()
    {
        Time.timeScale = 1f;
        Debug.Log("function called");
        
        userInterface.SetActive(true);
        pauseMenu.SetActive(false);
        _state = State.off;
        
    }
    public void backToPause()
    {
        pauseMenu.SetActive(true);
        optionMenu.SetActive(false);
    }
    public void toOptionMenu()
    {
        pauseMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    private void Update()
    {
        switch (_state)
        {
            case State.off:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Pause();
                }
                break;
            case State.pauseMenu:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Resume();
                }
                break;
            case State.optionMenu:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    backToPause();
                }
                break;
        }
    }
}
