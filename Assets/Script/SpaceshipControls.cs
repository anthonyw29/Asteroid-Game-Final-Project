﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipControls : MonoBehaviour
{
    public float moveSpeed =  50f;
    public float turnSpeed = -40f;
    public float deathForce = 7f;

    public float screenTop = 21f;
    public float screenBottom = -21f;
    public float screenRight = 36f;
    public float screenLeft = -36f;


    private Rigidbody2D rb;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //screen wrapping
        Vector2 newPos = transform.position;

        if(transform.position.y > screenTop)
        {
            newPos.y = screenBottom;
        }
        if(transform.position.y < screenBottom)
        {
            newPos.y = screenTop;
        }
        if (transform.position.x > screenRight)
        {
            newPos.x = screenLeft;
        }
        if (transform.position.x < screenLeft)
        {
            newPos.x = screenRight;
        }


        transform.position = newPos;
    }
    
    void FixedUpdate()
    {
        rb.AddForce(transform.up * movement.y * moveSpeed * Time.fixedDeltaTime);
        rb.AddTorque(movement.x * turnSpeed * Time.fixedDeltaTime);

        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if(collision.relativeVelocity.magnitude > deathForce)
        {
            Debug.Log("Death");
        }
    }
}
