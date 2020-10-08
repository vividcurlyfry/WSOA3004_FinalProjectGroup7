using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementScript : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed = 2f;
    public Vector2 motion;
    public Animator anim;
    public GridScript gs;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        motion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            anim.SetTrigger("FrontWalk");
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            anim.SetTrigger("Idle");

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            anim.SetTrigger("BackWalk");
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            anim.SetTrigger("Idle1");

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            anim.SetTrigger("LeftWalk");
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            anim.SetTrigger("Idle2");

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            anim.SetTrigger("RightWalk");
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            anim.SetTrigger("Idle3");

        if(transform.position.y < 9.9f && (transform.position.x >= -6f && transform.position.x <= 24.9))
        {
            gs.enabled = true;
        }
        else
        { 
            gs.enabled = false;
        }

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
