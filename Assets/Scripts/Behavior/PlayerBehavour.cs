using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Boundary horizontalBoundary;
    [SerializeField]
    private Boundary verticalBoundary;
    [SerializeField]
    bool isTestMobile;

    private GameController gameController;
    private PlayerHealth playerHealth; // Reference to PlayerHealth

    private bool isMobilePlatform = true;
    private Camera _Camera;
    private Vector2 destination;

    void Start()
    {
        _Camera = Camera.main;
        gameController = FindObjectOfType<GameController>();
        playerHealth = GetComponent<PlayerHealth>(); // Get PlayerHealth component

        if (!isTestMobile)
        {
            isMobilePlatform = Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;
        }
    }

    void Update()
    {
        if (isMobilePlatform)
        {
            GetTouchInput();
        }
        else
        {
            GetTraditionalInput();
        }

        move();
        CheckBoundaries();
    }

    void move()
    {
        transform.position = destination;
    }

    void GetTraditionalInput()
    {
        float axisX = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float axisY = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        destination = new Vector3(axisX + transform.position.x, axisY + transform.position.y, 0);
    }

    void GetTouchInput()
    {
        foreach (Touch touch in Input.touches)
        {
            destination = _Camera.ScreenToWorldPoint(touch.position);
            destination = Vector2.Lerp(transform.position, destination, speed * Time.deltaTime);
        }
    }

    // added from class 
    void CheckBoundaries()
    {
        if (transform.position.x > horizontalBoundary.max)
        {
            transform.position = new Vector3(horizontalBoundary.min, transform.position.y, 0);
        }
        else if (transform.position.x < horizontalBoundary.min)
        {
            transform.position = new Vector3(horizontalBoundary.max, transform.position.y, 0);
        }

        if (transform.position.y > verticalBoundary.max)
        {
            transform.position = new Vector3(transform.position.x, verticalBoundary.max, 0);
        }
        else if (transform.position.y < verticalBoundary.min)
        {
            transform.position = new Vector3(transform.position.x, verticalBoundary.min);
        }
    }

    //On trigger the player will take damage and lower the hit count,,,,, I am too tired for this 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Call the TakeDamage method from PlayerHealth
            playerHealth.TakeDamage();
        }
    }
}
