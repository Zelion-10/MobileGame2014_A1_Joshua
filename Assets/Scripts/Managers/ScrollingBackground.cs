using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField]
  private float speed= 3;
    private Vector3 direction= Vector3.down;
    [SerializeField]
    private Boundary boundry;
    [SerializeField]
    private Vector3 spawnPoint; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed*Time.deltaTime;

        if (transform.position.y < boundry.min)
        {
            transform.position = spawnPoint; 
        }
    }
}
