using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    Boundary VerticalSpeedRange;

    [SerializeField]
    Boundary HorizontalSpeedRange;


    float Verticalspeed;
   float Horizontalspeed;

    [SerializeField]
    Boundary verticalBoundary;

    [SerializeField]
    Boundary horizontalBoundary;

    SpriteRenderer spriteRenderer; // Reference to SpriteRenderer
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        Reset();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position= new Vector2(Mathf.PingPong(Horizontalspeed*Time.time,horizontalBoundary.max - horizontalBoundary.min )+ horizontalBoundary.min/*transform.position.x+ Horizontalspeed*Time.deltaTime*/,transform.position.y + Verticalspeed* Time.deltaTime);

        if(transform.position.y < verticalBoundary.min)
        {
            Reset();

        }

        //if (transform.position.x>horizontalBoundary.max|| transform.position.y > horizontalBoundary.min)
        //{
        //    Horizontalspeed = -Horizontalspeed;
        //}
    }

    public void DyingSequence()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void Reset()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        gameObject.SetActive(true);    
        transform.position = new Vector2(Random.Range(horizontalBoundary.min, horizontalBoundary.max), verticalBoundary.max);
        Verticalspeed = Random.Range(VerticalSpeedRange.min, VerticalSpeedRange.max);
        Horizontalspeed = Random.Range(HorizontalSpeedRange.min, HorizontalSpeedRange.max);
        spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
    }
}
