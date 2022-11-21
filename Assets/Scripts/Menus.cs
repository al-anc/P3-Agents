using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] bool settings;
    [SerializeField] GameObject SettingsMenu;
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
}
