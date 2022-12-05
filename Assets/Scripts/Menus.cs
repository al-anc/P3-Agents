using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menus : MonoBehaviour
{
    [SerializeField] bool settings;
    [SerializeField] bool Pause;
    [SerializeField] GameObject PauseMenu, HelpMenu, HelpFirstButton, HelpCloseButton;
    public void PlayGame()
    {
        Debug.Log("Game Started!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Debug.Log("Main menu loaded!");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    void Start()
    {
        settings = false;
    }
    void Update()
    {
        
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void OpenHelp()
    {
        PauseMenu.SetActive(false);
        HelpMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(HelpFirstButton);
    }

    public void CloseHelp()
    {
        HelpMenu.SetActive(false);
        PauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(HelpCloseButton);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Retry!");
        Time.timeScale = 1;
    }
    public void Pauses()
    {
        if (Pause == false)
        {
            PauseMenu.SetActive(true);
            Pause = true;
            Time.timeScale = 0;
        }
        else
        {
            //OpenSettings();
            PauseMenu.SetActive(false);
            Pause = false;
            Time.timeScale = 1;
        }
    }
}
