﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementScript : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed = 2f;
    public Vector2 motion;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();  
    }

    private void Update()
    {
        motion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }


    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb2D.velocity = motion * speed;
    }
}
