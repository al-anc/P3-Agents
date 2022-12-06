using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseControls : MonoBehaviour
{
    public GameObject  Player, PauseMenu, pauseMenuFirstButton;
    public bool paused;
    
    void Update()
    {
        if (!Player.GetComponent<PlayerMovement>().gameOver)
        {
            if (Input.GetButtonDown("Pause") && paused == false)
        {
            PauseMenu.SetActive(true);
            paused = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Input.GetButtonDown("Pause") && paused == true)
        {
            PauseMenu.SetActive(false);
            paused = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            if (paused == false)
            {
                PauseMenu.SetActive(false);
            }
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(pauseMenuFirstButton);
        }   
        }  
    }
}
