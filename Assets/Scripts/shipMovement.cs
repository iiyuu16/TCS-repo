using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{

    Rigidbody body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

void Start ()
    {
        body = GetComponent<Rigidbody>();
    }

void Update()
    {
   // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0){ // Check for diagonal movement
    
      // limit movement speed diagonally, so movement is at 70% speed
        horizontal *= moveLimiter;
        vertical *= moveLimiter;
        } 

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}