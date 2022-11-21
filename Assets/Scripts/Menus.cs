using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] bool settings;
    [SerializeField] bool Pause;
    [SerializeField] GameObject SettingsMenu;
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
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
        if (Input.GetButtonDown("Submit"))
        {
            PlayGame();
        }
        if (Input.GetButtonDown("Settings"))
        {
            Settings();
        }
        if (Input.GetButtonDown("Pause"))
        {
            Pauses();
        }
        if (Input.GetButtonDown("Submit") && Pause == true)
        {
            RetryLevel();
        }
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void Settings()
    {
        if (settings == false)
        {
            SettingsMenu.SetActive(true);
            settings = true;
        }
        else
        {
            SettingsMenu.SetActive(false);
            settings = false;
        }
    }
    public void SettingsInactive()
    {
        SettingsMenu.SetActive(false);
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
            PauseMenu.SetActive(false);
            Pause = false;
            Time.timeScale = 1;
        }
    }
}
