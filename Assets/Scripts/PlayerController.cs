﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float thrust = 10.0f;
    public LayerMask groundLayerMask;
    public Animator animator;
    public float runSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive", true);
    }
    private void FixedUpdate()
    {
        if(rigidBody.velocity.x < runSpeed)
        {
            rigidBody.velocity = new Vector2(runSpeed, rigidBody.velocity.y);
        }
    }
    // Update is called once per frame
    void Update()
    {

        bool isOnTheGround = IsOnTheGround();
        animator.SetBool("isGrounded", isOnTheGround);
        if ((Input.GetMouseButtonDown(0)

            || Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.W)
            ) && isOnTheGround
            )
        {
            Jump();
        }

    }
    void Jump()
    {
       
            rigidBody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
        
        
    }
    bool IsOnTheGround()
    {
       
     return Physics2D.Raycast(this.transform.position, Vector2.down,
            1.0f, groundLayerMask.value) ;
       
    }
}
