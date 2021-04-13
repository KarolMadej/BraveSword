using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovmentBasic : MonoBehaviour
{
    public CharacterController2D controller;
    private Rigidbody2D rb;
    public float runSpeed = 40f;
    public float CDTime = 2f;
    private float Timer = 0f;
    bool jump = false;
    bool crouch = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Dash()
    {
        if (transform.localScale.x == 1)
        {
            rb.velocity = new Vector2(runSpeed * 2, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-runSpeed * 2, rb.velocity.y);
        }
    }

    void Update()
    {
        if (Timer > 0) Timer -= Time.deltaTime;
        if (Timer < 0) Timer = 0;
        if (Input.GetKeyDown(KeyCode.LeftShift) && Timer == 0)
        {
            Dash();
            Timer = CDTime;
        }
        if (Input.GetButtonDown("Jump")) jump = true;
        if (Input.GetButton("Crouch")) crouch = true; 
        else crouch = false;
        controller.Move(Input.GetAxisRaw("Horizontal") * runSpeed * Time.deltaTime, crouch, jump);
        jump = false;
    }
}