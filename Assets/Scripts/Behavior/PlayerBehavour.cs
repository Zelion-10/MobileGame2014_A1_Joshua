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

    GameController gameController;

    bool isMobilePlatform = true;

    Camera _Camera;
    Vector2 destination;
    // Start is called before the first frame update
    void Start()
    {
        _Camera = Camera.main;
        gameController = FindAnyObjectByType<GameController>();

        if (!isTestMobile)
        {
            isMobilePlatform = Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isMobilePlatform)
        {
            GetTouchInput();
        }

        else
        {
            GetTriditionalInput();

        }

        move();
        Checkboundaries();



    }

    void move() { transform.position = destination; }
    void GetTriditionalInput()
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
    void Checkboundaries()
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


  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            
            gameController.ChangeScore(9);
            //Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);  
            collision.GetComponent<EnemyBehavior>().DyingSequence();
        }
            

        
    }
}