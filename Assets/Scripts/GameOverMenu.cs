using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]GameObject Player, gameOverFirstButton;
    [SerializeField]TMP_Text menuText;
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(gameOverFirstButton);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<PlayerMovement>().gameOver == true)
        {
            if (Player.GetComponent<PlayerMovement>().victory == false)
            {
                menuText.text = "Retry the level?";
            }
            if (Player.GetComponent<PlayerMovement>().victory == true)
            {
                menuText.text = "Good Work, Payload Retrieved!.";
            }
        }
    }
}
