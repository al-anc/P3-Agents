using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float deliveryTime;
    private bool countownStarted;
    public TextMeshProUGUI deliveryText;
    public TextMeshProUGUI timerText;
    private Vector3 velocity;
    private bool isGrounded;
    public GameObject Bomb;

    public bool gameOver, victory;

    [SerializeField]private GameObject GOverMenu;
    
    void Start()
    {
        Time.timeScale = 1;
        timerText.text = "";
        deliveryText.text = "";
    }
    
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        if (countownStarted)
        {
            Bomb.SetActive(true);
            deliveryTime -= Time.deltaTime;
            UpdateCountdown();
        }

        if (deliveryTime <= 0)
        {
            countownStarted = false;
            UpdateCountdown();
            Loss();
        }

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

        void UpdateCountdown()
    {
        timerText.text = ($"{deliveryTime.ToString("F0")}");
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == ("Victory") && countownStarted == true)
        {
            gameOver = true;
            victory = true;
            GOverMenu.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("You win");
        }
        if (col.gameObject.tag == ("BriefCase"))
        {
            countownStarted = true;
            deliveryText.text = "Get to the Exit!";
            Invoke(nameof(TextBlanks), 3); 
            col.gameObject.SetActive(false);
        }
    }

    public void Loss()
    {
        gameOver = true;
        victory = false;
        GOverMenu.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("You lose");
    }
    public void TextBlanks()
    {
        deliveryText.text = "";
    }
}
