using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menus : MonoBehaviour
{
    [SerializeField] bool settings;
    [SerializeField] bool Pause;
    [SerializeField] GameObject SettingsMenu, settingsFirstButton, settingsClosedButton;
    [SerializeField] GameObject PauseMenu;
    public void PlayGame()
    {
        Debug.Log("Game Started!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

    public void OpenSettings()
    {
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsFirstButton);
    }

    public void CloseSettings()
    {
        SettingsMenu.SetActive(false);
        PauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsClosedButton);
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
            OpenSettings();
            PauseMenu.SetActive(false);
            Pause = false;
            Time.timeScale = 1;
        }
    }
}
