﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    private float bulletForce = 50f;
    
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
           
    }

    void Shoot()
    {
        //fire and make bullet
        
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.up * bulletForce, ForceMode2D.Impulse);
        Destroy(newBullet, 3.0f);
       
    }
}
